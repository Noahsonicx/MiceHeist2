using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    [Header("Wave Attributes")]
    public Transform enemyPrefab;
    public Transform fastEnemyPrefab;
    public Transform strongEnemyPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public float timeBetweenWaves = 15f;

    private float countDown = 10f;
    [SerializeField] private int waveNumber = 1;
    private bool spawnPointBool = true;
    [SerializeField ,Range(0,1)]private float spawnChance = 0.2f;


    [Header("Wave UI Elements")]
    public Text waveNumberText;
    public Text waveCountdownText;

    public void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        // This is if the player ever gets above wave 150.
        if (waveNumber > 150)
        {
            timeBetweenWaves = 45;
        }

        // When the countdown reaches 0 start spawning next wave
        if (countDown <= 0)
        {
            waveNumber++;
            // Maybe put the wavenumber increment call here? instead of after the coroutine?? would coincide with the timer counting down.
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
            if (waveNumber < 25)
            {
                SpawnEnemy();
            }
            // This gives the player a chance to have a few towers on the field before we hit them with a faster mouse.
            if (waveNumber > 10)
            {
                SpawnFastEnemy();
            }
            if (waveNumber > 16)
            {
                SpawnStrongEnemy();
            }
            if (waveNumber > 50)
            {
                timeBetweenWaves = 30;
                yield return new WaitForSeconds(0.2f);
            }
            else
                yield return new WaitForSeconds(0.3f);
        }

        
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
        float _spawnChance = Random.Range(0f, 1f);
        if (waveNumber > 25)
        {
            _spawnChance = Random.Range(0f, 0.5f);
        }

        if (_spawnChance < spawnChance)
        {
            
            if (spawnPointBool)
            {
                Instantiate(fastEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
                Instantiate(fastEnemyPrefab, spawnPoint2.position, spawnPoint.rotation);
        }
    }

    /// <summary>
    /// This spawns a strong mouse if the chance is within range.
    /// </summary>
    public void SpawnStrongEnemy()
    {
        float _spawnChance = Random.Range(0f, 1f);
        if (waveNumber > 25)
        {
            _spawnChance = Random.Range(0f, 0.5f);
        }
        if (_spawnChance < spawnChance)
        {
            
            if (spawnPointBool)
            {
                Instantiate(strongEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
                Instantiate(strongEnemyPrefab, spawnPoint2.position, spawnPoint.rotation);
        }
    }

}
