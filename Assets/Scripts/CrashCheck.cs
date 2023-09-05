using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCheck : MonoBehaviour
{
    private bool crash = false;

    public bool getCrash()
    {
        return crash;
    }

    public void setCrash()
    {
        crash = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "grass") 
        {
            crash = true;
        }
    }
}
