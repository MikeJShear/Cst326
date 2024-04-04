using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject gameOverUi;
    public static bool gameEnd = false;

    void Start()
    {
        gameEnd = false;
    }

    void Update()
    {
        if(gameEnd)
        {
            return;
        }

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
        
        if(PlayerStats.Lives <=0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnd = true;
        Debug.Log("Game Over!!!");
        gameOverUi.SetActive(true);
    }
}
