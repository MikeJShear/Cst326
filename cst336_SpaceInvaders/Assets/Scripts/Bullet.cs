using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject.CompareTag("Invader1"))
            {
                Destroy(this.gameObject);
                Debug.Log("Invader1 hit");
            }
        
            if(other.gameObject.CompareTag("Invader2"))
            {
                Destroy(this.gameObject);
                Debug.Log("Invader2 hit");
            }

            if(other.gameObject.CompareTag("Invader3"))
            {
                Destroy(this.gameObject);
                Debug.Log("Invader3 hit");
            }

            if(other.gameObject.CompareTag("Invader4"))
            {
                Destroy(this.gameObject);
                Debug.Log("Invader4 hit");
            }

            if(other.gameObject.CompareTag("Invader5"))
            {
                Destroy(this.gameObject);
                Debug.Log("Invader5 hit");
            }

    }
}
