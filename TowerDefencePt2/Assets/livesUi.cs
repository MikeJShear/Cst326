using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class livesUi : MonoBehaviour
{
   public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives " + PlayerStats.Lives;
    }
}
