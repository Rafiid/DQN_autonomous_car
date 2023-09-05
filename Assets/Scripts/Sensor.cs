using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private int state = 0;

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "grass") 
        {
            state = 1;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "grass") 
        {
            state = 0;
        }

    }

    public int getState()
    {
        return state;
    }

}
