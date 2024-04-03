using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class enemyMovement : MonoBehaviour
{
    
    private int wavepointIndex = 0;
    private Transform target;
    private Enemy enemyObject;
    void Start()
    {
		enemyObject = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemyObject.speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemyObject.speed = enemyObject.startSpeed;
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            Destroy(gameObject);
            return;
        }
        wavepointIndex ++;
        target = Waypoints.points[wavepointIndex];
        
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
