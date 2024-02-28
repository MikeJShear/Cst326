using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{


    public TextMeshProUGUI Score;
    public TextMeshProUGUI coins;

    public TextMeshProUGUI goal;
    public float coinsTotal = 0f;
    public float score = 0f;

    public float acceleration = 10f;
    public float maxSpeed = 10f;
    public float jumpImpulse = 10f;
    public float jumpBoost;

    public GameObject brick;

    public bool isGrounded;           // true or false is grounded
    Ray upRay;
    Ray downRay;

    // Start is called before the first frame update
    void Start()
    {
        
        CheckForColliders();
    }

    void FixedUpdate()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();

        rbody.velocity += Vector3.right * horizontalMovement * Time.deltaTime * acceleration;
        

        Collider col = GetComponent<Collider>();


        CheckForColliders();


        Vector3 startPoint = transform.position;                    // create ray start point
        Vector3 endPoint = startPoint + Vector3.down * 2f;          // Create ray end

        isGrounded = Physics.Raycast(startPoint, Vector3.down, 2f); // rayStartpoint, ray direction, distance of units to check collision

        Color line = (isGrounded) ? Color.red : Color.blue;
        Debug.DrawLine(startPoint, endPoint, Color.blue, 0f, false);

        upRay = new Ray(transform.position,Vector3.up);
        downRay = new Ray(transform.position, Vector3.down);

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

private void CheckForColliders()
    {
        RaycastHit upHit;
        RaycastHit downHit;

        // Cast the up ray
        if (Physics.Raycast(upRay, out upHit, 2f))
        {
            //Debug.Log("Hit on top");  

            if(upHit.collider.CompareTag("Brick"))
            {
                score +=100;
                upHit.collider.gameObject.SetActive(false);
                SetCountText();
            } 
        }

        // Cast the down ray
        if (Physics.Raycast(downRay, out downHit,.1f))
        {
            //Debug.Log("Hit on bottom");
            if(downHit.collider.CompareTag("water"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Coin"))
            {
                other.gameObject.SetActive(false);
                score += 100;
                coinsTotal +=1;
                SetCountText();
            }
        
            else if(other.gameObject.CompareTag("pole"))
            {
                Debug.Log("Hit pole");
                goal.text = " !!!!! You Win !!!!!";
            }

    }

   void SetCountText()
    {
        Score.text ="Score: " + score.ToString(); // displayed text is equal to float countdown as string
        coins.text = "Coins: " +coinsTotal.ToString();
        
    }
    
}
