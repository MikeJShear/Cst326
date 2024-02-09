using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
   public Rigidbody rb;
   public float moveSpeed = 5f;
   public InputAction playerControls;
   
   Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }

   private void OnEnable() // enable player controls
   {
        playerControls.Enable();
   }

   private void OnDisable() // Disable player controls
   {
        playerControls.Disable();
   }

   void Update()
   {
    moveDirection = playerControls.ReadValue<Vector2>();
   }

   private void FixedUpdate()
   {
        Vector3 m_Input = new Vector3(moveDirection.x, 0, moveDirection.y);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
   }

   private void OnCollisionEnter(Collision collision)
   {
     //Debug.Log($"we hit {collision.gameObject.name}");
     
     
     Quaternion rotation = Quaternion.Euler(0f,0f,60f);
     Rigidbody rb = collision.rigidbody;

     Vector3 bounceDirection = rotation * Vector3.up;
     if (rb) 
     {
          rb.AddForce(bounceDirection * 1000f, ForceMode.Force);
     }
   }
}