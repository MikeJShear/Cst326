using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public Vector3 initialImpulse; // inital movement of the ball

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(initialImpulse,ForceMode.Force);
    }

    void Update()
    {

    }
}