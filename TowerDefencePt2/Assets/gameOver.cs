using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour
{
    public TextMeshProUGUI Rounds;
    void OnEnable()
    {
        Rounds.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }

}
