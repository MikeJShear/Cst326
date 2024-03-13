using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public GameObject obj;
    public UnityEvent<Collider> Object_onTriggerEnter; // listen for trigger events

    void OnTriggerEnter(Collider col) // take triggers as arguement
    {
        if (Object_onTriggerEnter != null && gameObject.CompareTag("Bullet") )     // if triggered event
        {
            Object_onTriggerEnter.Invoke(col); // invoke a collision event
            Debug.Log("BangBangBang");
        }
    }
}