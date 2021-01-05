using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject PauseMenuUI;
    public int SettingsUIOpen = 0;

    public void ResumeButton()                                
    {
        PauseMenuUI.SetActive(false);
    }

    public void SettingsButton()
    {
        SettingsUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        SettingsUIOpen = 1;
    }

    public void SettingsBackButton()
    {
        SettingsUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        SettingsUIOpen = 0;
    }

    public void ExitToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SettingsUIOpen == 0) //opens pause menu
        {
            PauseMenuUI.SetActive(true);
          
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SettingsUIOpen == 1) //close settings menu; open pause menu
        {
            SettingsUI.SetActive(false);
            PauseMenuUI.SetActive(true);
            SettingsUIOpen = 0;
        }

    }
}
