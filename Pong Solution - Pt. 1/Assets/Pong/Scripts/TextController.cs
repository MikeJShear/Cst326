using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMesh Pro

public class TextController : MonoBehaviour
{
//  Variable
public TextMeshProUGUI countText1; //p1 counter text
public TextMeshProUGUI countText2; //p2 counter text
public GameObject winTextObject;  // winner message
private int count1; // player1 counter declared
private int count2; // player2 counter declared

    // Start is called before the first frame update
    void Start()
    {
        count1 = 0; // start game with counters at 0
        count2 = 0; // start game with counters at 0
        SetCountText(); // set up counter text via function
        winTextObject.SetActive(false); // win message display set to false
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText1.text = "P1: "+ count1.ToString();    // set count1 text to p1:
        countText2.text = "P2: "+ count2.ToString();
    }

    

        private void OnTriggerEnter(Collider other) // object collection
    {
        if(other.gameObject.CompareTag("Left Goal"))  
        {
            other.gameObject.SetActive(false);
            count2 = count2 + 1;
            SetCountText();
        }

        else if(other.gameObject.CompareTag("Right Goal"))
        {
            other.gameObject.SetActive(false);
            count1 = count1 + 1;
            SetCountText();
        }
    }
}
