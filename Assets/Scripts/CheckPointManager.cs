using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    //set the value of this variable to the number of control points on the map
    private static int check_point_quantity = 62;

    private int[] states = new int[check_point_quantity + 1];

    private int goal = 1;
    public CheckPointSensor checkPointSensor;

    void Awake()
    {
        checkPointSensor = FindObjectOfType<CheckPointSensor>();
    }
 
    public int getGoal()
    {
        return goal;
    }

    public void setGoal(int newGoal)
    {
        if(newGoal > check_point_quantity)
        {
            resetCheckPoints();
        }
        else
        {
            goal = newGoal;
        }
        
    }

    public int[] readCheckPoints()
    {
  
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("checkPoint");
        for(int i = 0; i < checkPoints.Length; i++)
        {
            states[i] = checkPoints[i].GetComponent<CheckPoints>().getState();

        }
        
        return states;
    }


    public void resetCheckPoints()
    {
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("checkPoint");
        for(int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].GetComponent<CheckPoints>().setState(0); 
            
        }

        goal = 1;
    }
}
