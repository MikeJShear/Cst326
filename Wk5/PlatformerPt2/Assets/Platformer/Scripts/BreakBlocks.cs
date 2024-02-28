using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class BreakBlocks : MonoBehaviour
{
public TextMeshProUGUI Coins;
public TextMeshProUGUI Score;

public float coinsTotal = 0f;
public float score = 0f;


 private void OnTriggerEnter(Collider other) // object collider
    {
        Debug.Log("Trigger entered: " + other.gameObject.name);

        if(other.gameObject.CompareTag("Brick"))
        {
            score +=100;
            other.gameObject.SetActive(false);
            SetCountText();
        }

        else if(other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score += 100;
            coinsTotal +=1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        Coins.text ="Coins: " + coinsTotal.ToString(); // displayed text is equal to float countdown as string
        Score.text ="Score: " + score.ToString(); // displayed text is equal to float countdown as string
    }

}
