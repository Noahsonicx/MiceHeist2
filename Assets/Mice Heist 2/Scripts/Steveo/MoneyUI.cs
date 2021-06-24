using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    private void Update()
    {
        // Updates the Money text on the UI
        moneyText.text = PlayerStats.Money.ToString();
    }
}
