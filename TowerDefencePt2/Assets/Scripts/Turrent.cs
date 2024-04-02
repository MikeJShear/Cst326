using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    
    
    [Header("Standard")]

    public float range = 15f;

    [Header("Bullets")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public string enemyTag = "Enemy";

    [Header("Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem ImpactEffect;


    [Header("Required Unity Fields")]
    public Transform partToRotate;
    public float turrentSpeed = 10f;
    private Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                    {
                        lineRenderer.enabled = false;
                        ImpactEffect.Stop();
                    }
            }
            return;
        }
        LockOnTarget();
        if(useLaser)
        {
            Laser();
        }
       else
       {
            if (fireCountDown <=0)
            {
            Shoot();
            fireCountDown = 1f/fireRate;
            }
            fireCountDown -=Time.deltaTime;
       }
        
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position-transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turrentSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
    }

    void Laser()
    {
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            ImpactEffect.Play();
        }
        lineRenderer.SetPosition(0,firePoint.position);
        lineRenderer.SetPosition(1,target.position);

        
        Vector3 dir = firePoint.position - target.position ;
        
        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
        ImpactEffect.transform.position = target.position + dir.normalized;
        
    }
}
