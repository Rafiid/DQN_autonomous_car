using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float turnFaactor = 2.5f;
    private float maxSpeed = 50.0f;

    
    private float rotationAngle = 0;
    private Vector3 startPosition;
    private Quaternion startRotation;
    Rigidbody2D carRigidbody2D;
    
    public void setStartPosition()
    {
        transform.position  = startPosition;
        transform.rotation  = startRotation;
        
        //change this value to match the vehicle's initial rotation value on the map
        rotationAngle = 0;
    }

    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;

        ApplyEngineForce();
    }


    public void ApplyEngineForce()
    {
        carRigidbody2D.velocity = transform.up * maxSpeed;
    }

    public void ApplySteering(int steeringInput)
    {
        rotationAngle -= steeringInput * turnFaactor;
        carRigidbody2D.MoveRotation(rotationAngle);
    }
}
