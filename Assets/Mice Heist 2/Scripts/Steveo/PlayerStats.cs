using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public GameObject endPanel;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        endPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
