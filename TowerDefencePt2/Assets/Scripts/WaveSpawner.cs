using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countDown=2f;
    private int waveIndex = 0;

    public Transform  spawnPoint;

    public TextMeshProUGUI countdownText;

    void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown,0f,Mathf.Infinity);

        countdownText.text = string.Format("Time {0:00.00}",countDown);
    }

    IEnumerator SpawnWave()
    {
        
        for(int i = 0; i < waveIndex;i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation );
    }

}
