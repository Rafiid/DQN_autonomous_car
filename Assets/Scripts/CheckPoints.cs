using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    private int state = 0;

    public int getState()
    {
        return state;
    }

    public void setState(int newState)
    {
        state = newState;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "CarSprite") 
        {
            if(state == 0)
            {
                state = 1;     
            }
        }
    }
}
