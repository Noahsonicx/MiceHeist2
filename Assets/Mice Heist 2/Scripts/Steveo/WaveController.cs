using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    [Header("Wave Attributes")]
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public float timeBetweenWaves = 10f;

    private float countDown = 2f;
    private int waveNumber = 1;
    private bool spawnPointBool = true;

    [Header("Wave UI Elements")]
    public Text waveNumberText;
    public Text waveCountdownText;

    private void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);

        waveCountdownText.text = $"Next wave in: {string.Format("{0:00.00}", countDown)}";
        waveNumberText.text = "Wave: " + waveNumber.ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveNumber++;
        spawnPointBool = !spawnPointBool;
        Debug.Log("Wave incoming");
    }

    void SpawnEnemy()
    {
        if (spawnPointBool)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
            Instantiate(enemyPrefab, spawnPoint2.position, spawnPoint.rotation);
    }
}
