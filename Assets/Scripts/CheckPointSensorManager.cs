using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSensorManager : MonoBehaviour
{
    int[] states = new int[4];
    private int goal = 0;

    public void setGoal(int newGoal)
    {
        goal = newGoal;
    }

    public int[] readCheckPointSensors()
    {
        GameObject[] sensors = GameObject.FindGameObjectsWithTag("checkPointSensor");

        for(int i = 0; i < sensors.Length; i++)
        {   
            if(i == 0)
            {
                sensors[i].GetComponent<CheckPointSensor>().setGoal(goal);
            }
            else
            {
                sensors[i].GetComponent<CheckPointSensor>().setGoal(goal - 1);
            }
            
            states[i] = sensors[i].GetComponent<CheckPointSensor>().getState();  
        }

        return states;
    }


    public void setAllToZero()
    {
        GameObject[] sensors = GameObject.FindGameObjectsWithTag("checkPointSensor");

        for(int i = 0; i < sensors.Length; i++)
        {   
            sensors[i].GetComponent<CheckPointSensor>().setState(0);  
        }
    }


}
