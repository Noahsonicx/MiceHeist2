using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class GraphicsMenu : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();

        SetupOps();

        // Listen for the value of the dropdown due to OnOptionsChanged
        dropdown.onValueChanged.AddListener(OnOptionsChanged);
    }

    private void SetupOps()
    {
        // Removes all default options
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();
        // Loop through all quality settings 
        foreach (string quality in QualitySettings.names)
        {
            // New quality option
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(quality);
            newOptions.Add(option);
        }

        // Adding all the new options instead of the old ones
        dropdown.AddOptions(newOptions);
        // Setting the current value to the current quality and showing the value
        dropdown.value = QualitySettings.GetQualityLevel();
        dropdown.RefreshShownValue();
    }

    // Apply the quality setting to the game based on the new value of the dropdown
    private void OnOptionsChanged(int _option) => QualitySettings.SetQualityLevel(_option);

}
