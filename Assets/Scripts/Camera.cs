using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public void MoveCamera()
    {
       transform.position = new Vector3 (GameObject.Find("Car").transform.position.x, GameObject.Find("Car").transform.position.y, -10 );
    }
}
