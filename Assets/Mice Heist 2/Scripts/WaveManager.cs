using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    public int enemies;
    public float minSpawnRate, maxSpawnRate;
    public float delayToNext;
    public bool isRunning;
}

public class WaveManager : MonoBehaviour
{
    public bool gameOver = false;
    public Wave[] waveSettings;
    public GameObject[] enemyPrefabs;
    public int waveIndex = 0;

    public GameManager gameManager;

    private Transform[] points;
    private int enemyCount = 0;

    #region Unity Events
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        points = new Transform[children.Length - 1];
        for (int i = 1; i < children.Length; i++)
        {
            points[i - 1] = children[i];
        }

        StartNextWave();
    }

    IEnumerator StartWave(Wave currentWave)
    {
        if (PlayerStats.Lives <= 0)
        {
            Debug.Log("The game's supposed to end here");
            this.enabled = false;
        }

        while (enemyCount < currentWave.enemies) 
		{
			enemyCount++;

            int randPoint = Random.Range(0, points.Length);
            Transform point = points[randPoint];

            // Spawn enemy
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            GameObject prefab = enemyPrefabs[randEnemy];
			Instantiate(prefab, point.position, point.rotation);

            float rate = Random.Range(currentWave.minSpawnRate, currentWave.maxSpawnRate);

            yield return new WaitForSeconds(rate);
		}
        
        // If no enemies are left
        yield return new WaitForSeconds(currentWave.delayToNext);

        // Start new wave
        StartNextWave();

        enemyCount = 0;
        
        print("Current Wave: " + (waveIndex + 1) + "");

        if (waveIndex == waveSettings.Length) 
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        
    }

    void StartNextWave()
    {
        // Get current wave
        Wave currentWave = waveSettings[waveIndex];
        // Run coroutine for spawning enemies on point
        StartCoroutine(StartWave(currentWave));
        // Increase index (for next wave)
        waveIndex++;
    }
    
    #endregion
    
}