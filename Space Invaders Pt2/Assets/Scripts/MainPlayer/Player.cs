using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
  public GameObject bullet;
  public TextMeshProUGUI GameOver;
  public float playerMoveSpeed = 5f;


  public AudioClip explosionClip;

  public float timer;
  public Transform shoottingOffset;
    // Update is called once per frame


    void Start()
    {

      GameOver.gameObject.SetActive(true);
    }




    void Update()
    {
      // Player movement
        
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
          transform.position += Vector3.right * playerMoveSpeed*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
          transform.position += Vector3.left * playerMoveSpeed*Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1)) // fires bullet
        {
          GameObject shot = Instantiate(bullet, shoottingOffset.position, Quaternion.identity); // creates bullet
          Destroy(shot, 5f);  // destroys bullet
        }

    }
    void OnTriggerEnter(Collider other)
    {
          if(other.gameObject.CompareTag("enemyBullet"))
          {

            GameOver.text = "Game Over";
            GameOver.gameObject.SetActive(true);
            AudioSource src = GetComponent<AudioSource>();
            src.PlayOneShot(explosionClip);

              InvokeRepeating("GameOverFunc", 3.0f, 1f); // repeat invokes a function starting at 5 seconds , every 7 seconds
              
            
          }
    }

    void GameOverFunc()
    {
      gameObject.SetActive(false);
      SceneManager.LoadScene("Credits");
    }
    
}
