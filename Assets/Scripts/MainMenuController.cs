using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject MainMenuUI;


    public void PlayButton()                                //start game
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsButton()                            //opens setting menu
    {
        SettingsUI.SetActive(true);            //makes setting menu visible
        MainMenuUI.SetActive(false);           //makes main menu invisible
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
    
}
