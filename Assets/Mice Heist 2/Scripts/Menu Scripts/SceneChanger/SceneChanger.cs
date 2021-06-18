using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void PauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }
}

