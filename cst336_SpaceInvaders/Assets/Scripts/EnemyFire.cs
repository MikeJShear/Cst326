using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class EnemyFire : MonoBehaviour
{
 public GameObject bullet;

  public float speed = 5;
  public Transform shoottingOffset;

    void Start()
    {
      InvokeRepeating("Shoot", 5.0f, 7.0f); // repeat invokes a function starting at 5 seconds , every 7 seconds
    }

    void Update()
    {
          
    }


    // Update is called once per frame
    private void Shoot()
    {
      
      
      if(gameObject.activeInHierarchy) // if invader exist
      {
         GameObject shot = Instantiate(bullet, shoottingOffset.position, Quaternion.identity); // creates bullet
         
      }
    }


   
}
