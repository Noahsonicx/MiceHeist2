using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//[RequireComponent(typeof(Slider))]
public class Audio : MonoBehaviour
{
    // Creating a private Audiomixer for your audio
    //[SerializeField]
    public AudioMixer mixer;
    // Serializing the Volume Parameters that have been exposed creating a private string
    //[SerializeField]
    //private string volumeParam;

    //private Slider slider;

    // Setting up the max and minimum values that the slider can go up to for the audios dB

    // Start is called before the first frame update
    void Start()
    {
        //slider = gameObject.GetComponent<Slider>();
        //slider.minValue = 0;
        //slider.maxValue = 1;
        //slider.value = PlayerPrefs.GetFloat(volumeParam, 1);
        //slider.onValueChanged.AddListener(_value => mixer.SetFloat(volumeParam, Remap(_value, 0, 1, -80, 0)));

    }
    public void VolSlider(float _volume)
    {
        //PlayerPrefs.SetFloat("volume", _volume);
        _volume = Remap(_volume);
        mixer.SetFloat("Master", _volume);
        
    }
    /*private void OnDestroy()
    {
        PlayerPrefs.SetFloat(volumeParam, slider.value);
        PlayerPrefs.Save();
    }
    */
    // Remaps the values of the volume new max and min, with old min and max.
    public float Remap(float _value)
    {
        return -40 + (_value - 0) * (20 - -40) / (1 - 0);
    }
}