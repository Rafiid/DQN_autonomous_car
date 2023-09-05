using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public CarController carController;
    public CheckPointManager checkPointManager;
    public CarSensors carSensors;
    public CrashCheck crashCheck;   
    public Camera cammera;
    public CheckPointSensor checkPointSensor;
    public CheckPointSensorManager checkPointSensorManager;
    

    void Awake()
    {
        carController = FindObjectOfType<CarController>();
        checkPointSensorManager = FindObjectOfType<CheckPointSensorManager>();
        checkPointSensor = FindObjectOfType<CheckPointSensor>();
        checkPointManager = FindObjectOfType<CheckPointManager>();
        carSensors = FindObjectOfType<CarSensors>();
        crashCheck = FindObjectOfType<CrashCheck>();
        cammera = FindObjectOfType<Camera>();
    }

    public void NextFrame(int choice)
    {
        if(choice == 1)
        {
            carController.ApplySteering(-1);
        }


        if(choice == 2)
        {
            carController.ApplySteering(1);
        }

        carController.ApplyEngineForce();
        cammera.MoveCamera();  
    }


}
