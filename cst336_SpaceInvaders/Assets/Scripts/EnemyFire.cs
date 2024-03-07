using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class EnemyFire : MonoBehaviour
{
  private Rigidbody myRigidbody;

  public float speed = 5;
  
  public float timer;
  public GameObject bullet;
  public Transform shoottingOffset;

    void Start()
    {
      myRigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {

      timer = Time.deltaTime;
      if(timer%5 != 1)
        {
          Debug.Log("Enemy Fire");
          Shoot();
        }
    }


    // Update is called once per frame
    private void Shoot()
    {
      GameObject shot = Instantiate(bullet, shoottingOffset.position, Quaternion.identity); // creates bullet
      bullet.transform.Translate(new Vector3(0, -1, 0)); // moves down
      
      Destroy(shot, 5f);  // destroys bullet
    }


   
}
