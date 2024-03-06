using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public float speed = 5f;


  public Transform shottingOffset;
    // Update is called once per frame


    void Start()
    {
      
    }




    void Update()
    {
      // Player movement
        
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
          transform.Translate(new Vector3(speed*Time.deltaTime,0,0)); // transform player position right
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
          transform.Translate(new Vector3(-speed*Time.deltaTime,0,0)); // transform player position left
        }


      if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // fires bullet
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity); // creates bullet
        Destroy(shot, 7f);  // destroys bullet
      }


    }
}
