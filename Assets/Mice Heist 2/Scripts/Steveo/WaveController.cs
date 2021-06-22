using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    [Header("Wave Attributes")]
    public Transform enemyPrefab;
    public Transform fastEnemyPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public float timeBetweenWaves = 10f;

    private float countDown = 2f;
    private int waveNumber = 1;
    private bool spawnPointBool = true;
    [SerializeField ,Range(0,1)]private float fastSpawnChance = 0.2f;


    [Header("Wave UI Elements")]
    public Text waveNumberText;
    public Text waveCountdownText;

    private void Update()
    {
        // When the countdown reaches 0 start spawning next wave
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves; // reset timer
        }

        countDown -= Time.deltaTime; // Counts down timer

        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity); // clamps the timer to not fall below 0

        waveCountdownText.text = $"Next wave in: {string.Format("{0:00.00}", countDown)}";
        waveNumberText.text = "Wave: " + waveNumber.ToString();
    }

    /// <summary>
    /// Coroutine for spawning enemys one after another. Spawns the same amount of enemies as the wave number.
    /// </summary>
    IEnumerator SpawnWave()
    {        
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            // This gives the player a chance to have a few towers on the field before we hit them with a faster mouse.
            if (waveNumber > 10)
            {
                SpawnFastEnemy();
            }
            yield return new WaitForSeconds(0.5f);
        }

        waveNumber++; // Sets the wave number to next wave
        spawnPointBool = !spawnPointBool; // This bool then switches so the next wave spawns at the other spawn point
        Debug.Log("Wave incoming");
    }

    /// <summary>
    /// This handles actually instantiaing the enemys at the 2 different spawn points, based on the bool that gets changed after each wave has spawned.
    /// </summary>
    void SpawnEnemy()
    {
        if (spawnPointBool)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
            Instantiate(enemyPrefab, spawnPoint2.position, spawnPoint.rotation);
    }

    /// <summary>
    /// This spawns a fast mouse if the chance is within range.
    /// </summary>
    public void SpawnFastEnemy()
    {
        float spawnChance = Random.Range(0f, 1f);
        if (spawnChance < fastSpawnChance)
        {
            Debug.Log(spawnChance);
            if (spawnPointBool)
            {
                Instantiate(fastEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
                Instantiate(fastEnemyPrefab, spawnPoint2.position, spawnPoint.rotation);
        }
    }
    
}
