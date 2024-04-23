using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent enemies;
    public Transform Player;
    public float range = 25f;
    public string playerTag = "player";

    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,.5f);
    }

    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);  // find all potential players within game
        
        float shortestDiatance = Mathf.Infinity;
        GameObject closestPlayer = null;

        foreach (GameObject player in players) // using for loop for possible multiplayer functionalty, finding all players in game
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // return distance from enemies to player

            if(distanceToPlayer < shortestDiatance)
            {
                shortestDiatance = distanceToPlayer;
                closestPlayer = player;
            }
        }

        if(closestPlayer != null && shortestDiatance <= range)
        {
            Player = closestPlayer.transform;
        }
    }

    void Update()
    {
        if (Player == null)
        {
            return;
        }
        else
        {
            enemies.SetDestination(Player.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
