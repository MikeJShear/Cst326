using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio =gameObject.GetComponent<AudioSource>();
        Debug.Log("start in gameOver");
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameObject.activeInHierarchy)
        // {
        //     Debug.Log("is now active");
        //     audio.UnPause();
        // }
        // else {
        //     Debug.Log("is inactive");
        // }
    }
}
