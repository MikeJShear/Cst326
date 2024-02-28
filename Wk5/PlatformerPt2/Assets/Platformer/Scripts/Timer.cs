using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; //import text mesh pro to display 3d text

public class Timer : MonoBehaviour // code for countdown Timer
{
public float countDown = 100f;
public TextMeshProUGUI timer;
public TextMeshProUGUI gameOver;


    void Start()
    {
        SetCountText();
         
    }




    void Update()
    {
        if(countDown >0)  // if count timer greater than 0
        {
            countDown -= Time.deltaTime; //subtract time from timer total   
        }

        if(countDown < 0)  // if count timer greater than 0
        {
            gameOvert(); 
        }

        SetCountText();
    }

    void SetCountText()
    {
        timer.text ="Time: " + countDown.ToString("n0"); // displayed text is equal to float countdown as string
    }


    void gameOvert()
    {
        gameOver.text = "Game Over";
    }
}
