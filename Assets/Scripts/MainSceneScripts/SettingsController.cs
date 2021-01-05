using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    float currentVolume;

    Resolution[] resolutions;          
   
    // Start is called before the first frame update
    void Start()
    {

        resolutions = Screen.resolutions;

        List<string> ResolutionOptions = new List<string>();                        //create list of strings with our options

        int currentResolutionIndex = 0;

        for (int j = 0; j < resolutions.Length; j++)                                //create a formatted string for our resolution
        {
            string option = resolutions[j].width + "x" + resolutions[j].height;     //"width" + "x" + "height"
            ResolutionOptions.Add(option);                                                    // added to our options list

            if (resolutions[j].width == Screen.currentResolution.width && resolutions[j].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = j;
            }
        }

        resolutionDropdown.AddOptions(ResolutionOptions);             //added our options list to our resolution dropdown
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);

    }

    public void SetResolution(int resolutionIndex)                                     //set resolution
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        currentVolume = volume;
    }

    public void SetGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
        graphicsDropdown.value = graphicIndex;


    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SaveSettings()                              //save settings
    {
        PlayerPrefs.SetInt("GraphicSettings", graphicsDropdown.value);
        PlayerPrefs.SetInt("ResolutionSettings", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenSettings", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumeSettings", currentVolume);
    }

    public void LoadSettings(int currentResolutionIndex)            //load settings
    {
        if (PlayerPrefs.HasKey("GraphicSettings"))
        {
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicSettings");
        }
        else
        {
            graphicsDropdown.value = 3;
        }


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

   
}
