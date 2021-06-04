using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    
    /// <summary>
    /// Load Scene function that can be used for any scene by declaring name
    /// </summary>
    /// <param name="sceneName">the scene name to load</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
