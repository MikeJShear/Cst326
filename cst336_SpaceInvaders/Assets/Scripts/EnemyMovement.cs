using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyMovement : MonoBehaviour
{
    
    public float timer;
    public float acceleration = .005f;
    private Rigidbody2D rb; // declare rb as 2d rigid body

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>(); // get component from game object
        timer += Time.deltaTime;
        
         Vector2 movementRight = Vector2.right * timer*acceleration;
         rb.AddForce(movementRight,ForceMode2D.Impulse);// moves object to right
    }

    private void OnTriggerEnter(Collider other)
    {

        
            if(other.gameObject.CompareTag("Left Wall"))
            {
                Debug.Log(" Left Wall");
                Vector2 movementRight = Vector2.right * timer*acceleration;
                rb.AddForce(movementRight,ForceMode2D.Impulse);// moves object to right
            }
        
            else if(other.gameObject.CompareTag("Right Wall"))
            {
                Debug.Log(" Right Wall");
                Vector2 movementLeft = Vector2.left * timer*acceleration;
                rb.AddForce(movementLeft,ForceMode2D.Impulse);// moves object to right
            }

    }
}
