using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Start Attributes")]
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    [Header("End game UI panel")]
    public GameObject endPanel;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        endPanel.SetActive(false);
        Time.timeScale = 1; // Sets the time scale back to 1 in case of restart
    }

    private void Update()
    {
        // Test for Game Over
        if (Lives <= 0)
        {
            EndGame();
        }
    }

    /// <summary>
    /// Game Over Function
    /// </summary>
    public void EndGame()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
