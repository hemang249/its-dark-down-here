using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
   
    [Header("Audio Clips")]
    public AudioSource selectedAudioSource;
    public AudioClip[] audioClips;

    [Space]
    [Header("Refrences")]
    public GameObject FearPanel;
    private Fear fear;
    private int fearState = 0;
    private int previousState = 0;
    private bool played = false;

    void Start()
    {
        selectedAudioSource = GetComponent<AudioSource>();
        fear = FearPanel.GetComponent<Fear>();
        
    }

    // Update is called once per frame
    void Update()
    {
        fearState = (int) fear.currentState;
        SelectAudioSource();

        if(previousState != fearState)
        {
            played = false;
            previousState = fearState;
          
        }

        if(selectedAudioSource != null && !played)
        {
            selectedAudioSource.Play();
            played = true;
        }  
    }

    void SelectAudioSource()
    {
         selectedAudioSource.clip = audioClips[fearState];
    }
}
