using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject MainMenuUI;
    public bool SettingMenuOpen = false;
    public float crossfadeTime = 1f;

    public void PlayButton()                                //start game
    {
        CrossfadeScene();
        
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsButton()                            //opens setting menu
    {
        SettingsUI.SetActive(true);            //makes setting menu visible
        MainMenuUI.SetActive(false);           //makes main menu invisible
        SettingMenuOpen = true;
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

    public void TutorialButton()
    {
        CrossfadeScene();
        SceneManager.LoadScene("Tutorial");
    }

    public void QuizButton()                                //start game
    {
        CrossfadeScene();
        SceneManager.LoadScene("Quiz");
    }

    IEnumerator CrossfadeScene()                            //plays the crossfade ui
    {
        GetComponent<Animator>().Play("crossfadeAnimation", -1, 0f);
        
        yield return new WaitForSeconds(crossfadeTime); //waiting time
    }

    void Update()
    {

        Scene activeScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Escape) && SettingMenuOpen == true) //when the settings are open and you press escape, you get to the MainMenu  
        {
       
            MainMenuUI.SetActive(true);             
            SettingsUI.SetActive(false);            
            SettingMenuOpen = false;

        }

        if (Input.GetKeyDown(KeyCode.Escape) && activeScene.name  == "Credits")  // if the scene Credit is open and you press escape, you will get to the mainmenu
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}
