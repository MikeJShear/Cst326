using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI highScoreText;
    private float score = 0;
    public float highScore = 0;

    public AudioClip explosionClip;



    // Start is called before the first frame update
    void Start()
    {
        score = float.Parse(totalScore.text);

        if (PlayerPrefs.HasKey("highScore")) 
        {
            highScore = PlayerPrefs.GetFloat("highScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = float.Parse(totalScore.text);      
        SetScoreText();
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
                GetComponent<Animator>().SetTrigger("hit");
                GetComponent<Animator>().SetTrigger("bang");
                GetComponent<Animator>().SetTrigger("Bang");
                GetComponent<Animator>().SetTrigger("bigBoom");
                other.gameObject.SetActive(false);
                AudioSource src = GetComponent<AudioSource>();
                src.PlayOneShot(explosionClip);

                InvokeRepeating("Deleted", 1.0f, 1f); // repeat invokes a function starting at 5 seconds , every 7 seconds
                SetScoreText();
            }
    }

    void SetScoreText()
    {
        if(highScore< score)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        totalScore.text = ""+ score.ToString("0000");
        highScoreText.text = highScore.ToString("0000");
    }

    void Deleted()
    {
        gameObject.SetActive(false);
    }
}
