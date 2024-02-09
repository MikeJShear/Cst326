// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]

// public class Ball : MonoBehaviour
// {
//     Rigidbody rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();

//         ReturnToCenter();
//     }

//     public void ReturnToCenter()
//     {
//         int velocityX = Random.Range(1,3) ==1 ? Random.Range(-4,-7): Random.Range(4,7);
//         int velocityZ = Random.Range(1,3) ==1 ? Random.Range(-4,-7): Random.Range(4,7);
//         rb.velocity = new Vector3(velocityX,0,velocityZ);
//         transform.position = new Vector3(0,0,11);
//     }
// }