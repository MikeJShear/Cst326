using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float acceleration = 10f;
    public float maxSpeed = 10f;
    public float jumpImpulse = 10f;
    public float jumpBoost;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();

        rbody.velocity += Vector3.right * horizontalMovement * Time.deltaTime * acceleration;
        

        Collider col = GetComponent<Collider>();


        //Debug.Log(rbody.velocity);


        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * 2f;

        isGrounded = Physics.Raycast(startPoint, Vector3.down, 2f);

        Color line = (isGrounded) ? Color.red : Color.blue;
        Debug.DrawLine(startPoint, endPoint, Color.blue, 0f, false);

        

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            rbody.AddForce(Vector3.up * jumpImpulse,ForceMode.Impulse);
        }

        else if(!isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            if(rbody.velocity.y > 0)
            {
                rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
            }
        }

       
        if (Math.Abs (rbody.velocity.x) > maxSpeed)
        {
            Vector3 newVel = rbody.velocity;
            newVel.x = Math.Clamp(newVel.x, -maxSpeed, maxSpeed);
            rbody.velocity = newVel;
            
            //rbody.velocity = rbody.velocity.normalized * maxSpeed;
        }

       

       
    }
}
