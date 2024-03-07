using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
 
    public float timer;
    private GameObject obj;
    void Start()
    {

    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
        }
    }
}
