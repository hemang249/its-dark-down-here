using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameWithWait()
    {
        Invoke ("PlayGame", 1.0f);
    }

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
