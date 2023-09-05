using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using System;
using Unity.MLAgents.Sensors;
using UnityEngine.InputSystem;

public class CarAgent : Agent
{
    private int[] sensors;
    private int[] checkPoints;
    private int[] checkPointSensors;
    private int goal;

    Type gameManagerType = typeof(GameManager);
    GameManager gameManager;
    

    public override void Initialize()
    {
        gameManager = (GameManager)gameObject.AddComponent(gameManagerType);
    }

    private void Reset()
    {
        gameManager.carController.setStartPosition();
        gameManager.crashCheck.setCrash();
        gameManager.checkPointManager.resetCheckPoints();
    }
  

    public override void OnActionReceived(ActionBuffers actions)
    {
        if(actions.DiscreteActions[0]==0)
        {
            gameManager.NextFrame(0);
        }
        
        if(actions.DiscreteActions[0]==1)
        {
            gameManager.NextFrame(1);
        }

        if(actions.DiscreteActions[0]==2)
        {
            gameManager.NextFrame(2);
        }

        goal = gameManager.checkPointManager.getGoal();

        checkPoints = gameManager.checkPointManager.readCheckPoints();
        
        gameManager.checkPointSensorManager.setGoal(goal);
        checkPointSensors = gameManager.checkPointSensorManager.readCheckPointSensors();

        //Debug.Log(checkPointSensors[0] + " " + checkPointSensors[1] + " " + checkPointSensors[2] + " " + checkPointSensors[3]);

        if(gameManager.crashCheck.getCrash()==true)
        {
            AddReward(-1.0f);
            Reset();
        }
        else if(checkPoints[goal - 1] == 1)
        {
            AddReward(1.0f);
            gameManager.checkPointManager.setGoal(goal + 1);
        }
        else if(checkPointSensors[0] == 1 && checkPointSensors[1] == 1)
        {               
            AddReward(0.1f);
        }
        else
        {
            AddReward(-0.5f);
        }

        gameManager.checkPointSensorManager.setAllToZero();
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        sensors = gameManager.carSensors.readSensors();
        goal = gameManager.checkPointManager.getGoal();
        checkPoints = gameManager.checkPointManager.readCheckPoints();
        gameManager.checkPointSensorManager.setGoal(goal);
        checkPointSensors = gameManager.checkPointSensorManager.readCheckPointSensors();

        for(int i=0; i<checkPointSensors.Length; i++)
        {
           sensors[15 + i] = checkPointSensors[i];
        }

        for(int i=0; i<19; i++)
        {
            sensor.AddObservation(sensors[i]);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var action = actionsOut.DiscreteActions;
        
        
        if(Keyboard.current.upArrowKey.isPressed)
        {
            action[0] = 0;
        }

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            action[0] = 1;
        }

        if(Keyboard.current.rightArrowKey.isPressed)
        {
            action[0] = 2;
        }

    }
}