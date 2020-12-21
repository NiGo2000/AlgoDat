using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public AudioMixer audioMixer;

    Resolution[] resolutions;
   
    // Start is called before the first frame update
    void Start()
    {

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();                                          //clear all options

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
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)                                     //set resolution
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
