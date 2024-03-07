using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody myRigidbody;

  public float speed = 5;

  public float score = 0;
  
  


    void Start()
    {
      myRigidbody = GetComponent<Rigidbody>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody.velocity = Vector3.up * speed; 
    }


   
}
