using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float acceleration = .1f;
  private Rigidbody2D rb; // declare rb as 2d rigid body


  public Transform shottingOffset;
    // Update is called once per frame


    void Start()
    {
      
    }




    void Update()
    {
      // Player movement
        rb = GetComponent<Rigidbody2D>(); // get component from game object
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
          rb.AddForce(Vector2.right * acceleration,ForceMode2D.Impulse);// moves player to right
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
          rb.AddForce(Vector2.left * acceleration,ForceMode2D.Impulse);// moves player to right
        }


      if (Input.GetKeyDown(KeyCode.Space)) // fires bullet
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity); // creates bullet
        Destroy(shot, 3f);  // destroys bullet
      }


    }
}
