using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class BreakBlocks : MonoBehaviour
{
public TextMeshProUGUI Coins;

public float coinsTotal = 0f;

 private void OnTriggerEnter(Collider other) // object collider
    {
        Debug.Log("Trigger entered: " + other.gameObject.name);

        if(other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.SetActive(false);
        }

        else if(other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coinsTotal +=1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        Coins.text ="Coins: " + coinsTotal.ToString(); // displayed text is equal to float countdown as string
    }

}
