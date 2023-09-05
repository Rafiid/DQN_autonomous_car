using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSensors : MonoBehaviour
{
    int[] states = new int[19];

    public int[] readSensors()
    {
        GameObject[] sensors = GameObject.FindGameObjectsWithTag("sensor");
        for(int i = 0; i < sensors.Length; i++)
        {
            states[i] = sensors[i].GetComponent<Sensor>().getState();  
        }

        return states;
    }
}
