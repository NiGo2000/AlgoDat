using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject PauseMenuUI;
    public GameObject GameSceneUI;
    public GameObject PauseMenuCamera;
    public GameObject Background;
    public bool SettingsUIOpen = false;
    


    public void ResumeButton()                                
    {

        Background.SetActive(false);
        PauseMenuUI.SetActive(false);
        GameSceneUI.SetActive(true);
        PauseMenuCamera.SetActive(false);
        Time.timeScale = 1;

    }

    public void SettingsButton()
    {
        SettingsUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        SettingsUIOpen = true;
    }

    public void SettingsBackButton()
    {
        SettingsUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        SettingsUIOpen = false;
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
        if (Input.GetKeyDown(KeyCode.Escape) && SettingsUIOpen == false) //opens pause menu
        {
            Time.timeScale = 0;
            Background.SetActive(true);
            PauseMenuCamera.SetActive(true);
            GameSceneUI.SetActive(false);
            PauseMenuUI.SetActive(true);
           

        }

        if (Input.GetKeyDown(KeyCode.Escape) && SettingsUIOpen == true) //close settings menu; open pause menu
        {
            SettingsUI.SetActive(false);
            PauseMenuUI.SetActive(true);
            SettingsUIOpen = false;
        }

    }

    
}
