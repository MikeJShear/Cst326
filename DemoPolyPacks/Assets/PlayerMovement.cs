using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{


    public Transform agentDestination;

    void Start()
    {
        
    }

    
    void Update()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.destination = agentDestination.position; 
    }
}
