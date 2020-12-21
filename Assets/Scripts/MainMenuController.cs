using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject MainMenuUI;
    public int SettingMenuOpen = 0;                     //0 = false ; 1 = true

    public void PlayButton()                                //start game
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsButton()                            //opens setting menu
    {
        SettingsUI.SetActive(true);            //makes setting menu visible
        MainMenuUI.SetActive(false);           //makes main menu invisible
        SettingMenuOpen = 1;
    }

    public void CreditsButton()                                //switch Credits-Scene
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitButton()                                //quit application
    {
        Application.Quit();
    }

    public void BackButton()                                //return to the main menu
    {
        MainMenuUI.SetActive(true);             //makes main menu visible
        SettingsUI.SetActive(false);            //makes setting menu invisible
    }

    void Update()
    {

        Scene activeScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Escape) && SettingMenuOpen == 1) //when the settings are open and you press escape, you get to the MainMenu  
        {
       
            MainMenuUI.SetActive(true);             
            SettingsUI.SetActive(false);            
            SettingMenuOpen = 0;

        }

        if (Input.GetKeyDown(KeyCode.Escape) && activeScene.name  == "Credits")  // if the scene Credit is open and you press escape, you will get to the mainmenu
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}
