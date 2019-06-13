﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeIn;
    public VideoPlayer MainMenuVideo;

    void Start()
    {
    }

    public void PlayGame()
    {
        ClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    /*
     * public void PlayGameWithWait()
    {
        Invoke ("PlayGame", 3.0f);
    }
    */

    public AudioSource uiSounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public AudioSource UiSounds { get => uiSounds; set => uiSounds = value; }

    public void HoverSound()
    {
        uiSounds.PlayOneShot (hoverSound);
    }

    public void ClickSound()
    {
        uiSounds.PlayOneShot(clickSound);
    }

}
