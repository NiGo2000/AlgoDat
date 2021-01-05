using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] tracks;
    private AudioSource audioSource;

   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }

    private AudioClip GetRandomClip()               //randomizes the order of the songs
    {
        return tracks[Random.Range(0, tracks.Length)];
    }

    void Awake()                                   //no music interruption when changing scenes
    {
            GameObject.DontDestroyOnLoad(transform.root.gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        if (!audioSource.isPlaying)  //plays the songs
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }

        if (activeScene.name == "Credits")      //should the scene credits be open, the music will be interrupted
        {
            Destroy(gameObject);
        }
    }
}
