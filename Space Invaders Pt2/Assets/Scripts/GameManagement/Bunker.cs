using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

         void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("enemyBullet"))
            {
                    gameObject.SetActive(false);
                    other.gameObject.SetActive(false);
                    
            }
    }
}
