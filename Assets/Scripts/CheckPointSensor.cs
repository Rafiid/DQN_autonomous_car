using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSensor : MonoBehaviour
{
    private int state = 0;
    private int goal = 0;

    public int getState()
    {
        return state;
    }

    public void setState(int newState)
    {
        state = newState;
    }

    public void setGoal(int newGoal)
    {
        goal = newGoal;
    }
    
    void OnTriggerStay2D(Collider2D other)
    {

        if(other.gameObject.name == "CheckPoint (" + goal +")") 
        {
            state = 1;     
        }
    }
}
