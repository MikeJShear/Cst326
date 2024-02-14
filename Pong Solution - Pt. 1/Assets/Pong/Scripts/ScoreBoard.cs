using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    private int Player1Score; // player 1 score initialized
    private int Player2Score; // player 2 score  initialized

    public TextMeshProUGUI counter1;   // pl UGUI
    public TextMeshProUGUI counter2;   // p2 UGUI

    public GameObject winner1; // winner Message
    public GameObject winner2; // winner Message
    public AudioSource Goal;
    // Start is called before the first frame update
    void Start()
    {
        Player1Score = 0;
        Player2Score = 0;
        SetCountText(); 


        winner1.SetActive(false);
        winner2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Right Goal"))
        {
            Player1Score +=1;
            Goal.Play();
            SetCountText(); 
            CheckWin();
        }

        else if(other.gameObject.CompareTag("Left Goal"))
        {
            Player2Score +=1;
            Goal.Play();
            SetCountText(); 
            CheckWin();
        }
    }

    void SetCountText()
    {
        counter1.text = Player1Score.ToString(); // displays default score
        counter2.text = Player2Score.ToString(); // displays default score

    }

    void CheckWin()
    {
        if(Player1Score >=11)
        {
            winner1.SetActive(true);
        }

        else if(Player2Score >=11)
        {
            
            winner2.SetActive(true);
        }
    }
}
