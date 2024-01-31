using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float yawDegreePerSecond = 45f;
    public GameObject planet;
    public float orbit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = GetComponent<Transform>();
        myTransform.Rotate(new Vector3(0f,yawDegreePerSecond * Time.deltaTime,0f),Space.World);
       
        transform.RotateAround(planet.transform.position, Vector3.up, orbit* Time.deltaTime);

    }
}
