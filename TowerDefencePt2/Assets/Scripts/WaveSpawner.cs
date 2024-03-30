using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        countdownText.text = Mathf.Round(countDown).ToString("00");
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
