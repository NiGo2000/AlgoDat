using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public AudioMixer backgroundAudio;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    float currentVolume;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> ResolutuinsOption = new List<string>();                   //create list of strings with our options

        int currentResolutionsIndex = 0;

        for(int j = 0; j < resolutions.Length; j++)
        {
            string options = resolutions[j].width + "x" + resolutions[j].height + " " + resolutions[j].refreshRate.ToString() + "Hz";         //width + "x" + height + Hz
          
            ResolutuinsOption.Add(options);                                                 //added to our option list
                
            if (resolutions[j].width == Screen.width && resolutions[j].height == Screen.height)
             {
                currentResolutionsIndex = j;
             }
        }
    
        resolutionDropdown.AddOptions(ResolutuinsOption);  //added our options list to our resolution dropdown
        resolutionDropdown.value = currentResolutionsIndex;
        resolutionDropdown.RefreshShownValue();

        LoadSettings(currentResolutionsIndex); 
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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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

    public void SaveSettings()                              //save settings
    {
        PlayerPrefs.SetInt("ResolutionSettings", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenSettings", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumeSettings", currentVolume);
    }

    public void LoadSettings(int currentResolutionIndex)            //load settings //int currentResolutionIndex
    {
        if (PlayerPrefs.HasKey("ResolutionSettings"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionSettings");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
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
