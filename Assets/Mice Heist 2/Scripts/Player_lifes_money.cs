using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_lifes_money : MonoBehaviour
{
    public int StartLifes = 9;
    public static int lifes;

    public int startMoney = 15;
    public static int Money;

   private void start ()
    {
        startMoney = Money;
        StartLifes = lifes;

    }
   
}
