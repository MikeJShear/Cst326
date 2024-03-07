using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Score : MonoBehaviour
{

    // public Component invaders;
    // public Component invaders;

    public TextMeshProUGUI totalScore;

    private float score = 0;

    private Rigidbody rbody;

    private Vector3 increaseRate = new Vector3(0.01f,0,0);


    // Start is called before the first frame update
    void Start()
    {
        score = float.Parse(totalScore.text);
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        score = float.Parse(totalScore.text);
        // rbody.velocity = rbody.velocity + increaseRate;
    }


     void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Bullet"))
            {
                if(gameObject.tag.Contains("1"))
                {
                    score +=40;
                }
                
                else if(gameObject.tag.Contains("2"))
                {
                    score +=30;
                }

                else if(gameObject.tag.Contains("3"))
                {
                    score+=30;
                }

                else if(gameObject.tag.Contains("4"))
                {
                    score+=20;
                }

                else if(gameObject.tag.Contains("5"))
                {
                    score+=10;
                }
                
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);

                // float horizontalMovement = Input.GetAxis("Horizontal");
                // Rigidbody rbody = GetComponent<Rigidbody>();
                // rbody.constantForce.relativeForce = Vector3(0, 0, 1);
                
                SetScoreText();
            }
    }

    void SetScoreText()
    {
        totalScore.text = ""+ score.ToString("0000");
    }
}
