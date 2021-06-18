using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class OptionsMenu : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    private List<Resolution> resolutions;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        // Gather all resolutions set by this monitor
        resolutions = new List<Resolution>(Screen.resolutions);

        SetupOps();
        dropdown.onValueChanged.AddListener(OnResChanged);
    }

    private void SetupOps()
    {
        // Remove all default options such as Option A, B and C 
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();
        // Loop Resolutions
        foreach (Resolution resolution in resolutions)
        {
            // New option created 
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height}");
            newOptions.Add(option);
        }

        dropdown.AddOptions(newOptions);
        // Quality value
        dropdown.value = resolutions.IndexOf(Screen.currentResolution);
        dropdown.RefreshShownValue();
    }

    private void OnResChanged(int _res)
    {
        Resolution resolution = resolutions[_res];

        // Calculating the already set resolution and other resolutions
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }
}