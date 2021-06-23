using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public void OnClickPause()
    {
        if(Time.timeScale == 1.0f)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void OnClickUnPause()
    {
        if (Time.timeScale == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
