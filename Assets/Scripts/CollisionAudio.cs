using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
   public AudioSource[] audioSource;
   private AudioSource selectedAudioSource;    
   public GameObject FearPanel;
   private Fear fear;
   private int fearState;
   private bool played = false;
   void Start()
   {
       FearPanel = GameObject.FindGameObjectWithTag("FearPanel");
        fear = FearPanel.GetComponent<Fear>();
   }

   void Update()
   {
       fearState = (int)fear.currentState;
   }
   void SelectAudioClip()
   {
       switch(fearState)
       {
           case 0: selectedAudioSource = audioSource[fearState]; break;
           case 1: selectedAudioSource = audioSource[fearState]; break;
           case 2: selectedAudioSource = audioSource[fearState]; break;
           case 3: selectedAudioSource = audioSource[fearState]; break;
       }
   }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") && !played)
        {
            played = true;
            selectedAudioSource.Play();
            
        }
    }
}
