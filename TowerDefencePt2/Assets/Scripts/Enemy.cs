using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public int health = 5;
    public int moneyGain = 100;
    public GameObject deathEffect;
    void Start()
    {
        target = Waypoints.points[0];
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if(health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.Money += moneyGain;
        Destroy(gameObject);
        
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex ++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives --;
        Destroy(gameObject);
    }
}
