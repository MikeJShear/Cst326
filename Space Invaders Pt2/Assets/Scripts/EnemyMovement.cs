using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;



public class EnemyMovement : MonoBehaviour
{
    public float invaderSpeed = .25f;
    private bool moveInvaderRight = true; // alternates between true and false

    private Component[] children;
    public TextMeshProUGUI killedInvaders;

    public TextMeshProUGUI remainingInvaders;
    private float invadersHit = 0;
    private float invadersRemaining = 0;
    private int invaderCount = 0;

    void Start()
    {
        children = gameObject.GetComponentsInChildren<Rigidbody>();
        invaderCount = children.Length-1;
        // Debug.Log("count!: " + invaderCount);
    }

    void checkInvaders()
    {
        children = gameObject.GetComponentsInChildren<Rigidbody>();
        if (invadersRemaining != children.Length-1)
        {
            increaseSpeed();
            updateCounters();
        }
    }

    void increaseSpeed()
    {
        invaderSpeed+=.001f;
        Debug.Log("invader speed: " + invaderSpeed.ToString());
    }

    void updateCounters()
    {
        
        invadersRemaining = children.Length-1;
        invadersHit = invaderCount - invadersRemaining;
        killedInvaders.text = "Total Invaders Hit!: "+invadersHit.ToString("0000");
        remainingInvaders.text = "Invaders Remaining!: "+invadersRemaining.ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
         if(moveInvaderRight) // when moveInvaderRight true
         {
            transform.Translate(new Vector3(1*invaderSpeed,0,0)); //moveInvaderRight 
         }

         if(moveInvaderRight == false)  // when moveInvaderRight false
         {
            transform.Translate(new Vector3(-1*invaderSpeed,0,0)); // move invader left
         }

         checkInvaders();
    }

    void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Left Wall"))
            {
                //Debug.Log("Left Wall"); //debug
                moveInvaderRight = true;  // moveInvaderRight true (change Direction)
                // transform.Translate(new Vector3(0,-1,0)); // moves enemy down
                transform.Translate(new Vector3(0, -1, 0)); // moves enemy down
            }
        
            if(other.gameObject.CompareTag("Right Wall"))
            {
                //Debug.Log(" Right Wall"); //debug
                moveInvaderRight = false; // moveInvaderRight false (change Direction)
                // transform.Translate(new Vector3(0,-1,0)); // moves enemy down
                transform.Translate(new Vector3(0, -1, 0)); // moves enemy down
            }

    }
}
