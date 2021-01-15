using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitToMainMenu : MonoBehaviour
{
    public float crossfadeTime = 1f;

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //opens pause menu
        {
            Exit();
        }
    }
}
