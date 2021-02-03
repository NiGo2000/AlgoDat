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
    public Animator CrossfadeAnim;
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void OpenPauseMenuButton()
    {
        Time.timeScale = 0;
        Background.SetActive(true);
        PauseMenuCamera.SetActive(true);
        GameSceneUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    void Update()
    {
        if (this.CrossfadeAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)  //when the animation ends, you can open the pause menu with esc
        {
            if (Input.GetKeyDown(KeyCode.Escape) && SettingsUIOpen == false) //opens pause menu
            {
                OpenPauseMenuButton();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && SettingsUIOpen == true) //close settings menu; open pause menu
            {
                SettingsBackButton();
            }
        }
        else
        {
            Debug.Log("Loading Scene");
        }
    }

    
}
