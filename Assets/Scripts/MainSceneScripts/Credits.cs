using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator CreditsAnim;

    // Update is called once per frame
    void Update()
    {
        if (CreditsAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)  //when the animation ends it switches to the scene MainMenu
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("playing");
        }

  
    }
}
