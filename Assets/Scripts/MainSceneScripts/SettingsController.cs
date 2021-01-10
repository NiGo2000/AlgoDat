using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    public Dropdown qualityDropdown;
    public AudioMixer backgroundAudio;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    float currentVolume;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        LoadSettings(); 
    }
    
    public void Volume(float volume)
    {
        backgroundAudio.SetFloat("Volume", Mathf.Log10(volume) * 20);                 //set volume for 1 to 0 and for 0.0001 t0 -80 (MainMixerSound)
        currentVolume = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void FullscreenButton()
    {
        if(fullscreenToggle.isOn == true)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()                              //save settings
    {
        PlayerPrefs.SetInt("QualitySettings", qualityDropdown.value);
        PlayerPrefs.SetInt("FullscreenSettings", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumeSettings", currentVolume);
    }

    public void LoadSettings()            //load settings //int currentResolutionIndex
    {
        if (PlayerPrefs.HasKey("QualitySettings"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettings");
        }
        else
        {
            qualityDropdown.value = 3;
        }


        if (PlayerPrefs.HasKey("FullscreenSettings"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenSettings"));
        }
        else
        {
            Screen.fullScreen = true;
        }

        if (PlayerPrefs.HasKey("VolumeSettings"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumeSettings");
        }
        else
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumeSettings");
        }
    }

   void Update()
    {
        SaveSettings();
    }
}
