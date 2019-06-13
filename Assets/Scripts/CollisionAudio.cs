using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
   public AudioSource triggerAudioSource;    
   public GameObject FearPanel;
   private bool played = false;
  
  /*  void SelectAudioClip()
   {
       switch(fearState)
       {
           case 0: selectedAudioSource = audioSource[fearState]; break;
           case 1: selectedAudioSource = audioSource[fearState]; break;
           case 2: selectedAudioSource = audioSource[fearState]; break;
           case 3: selectedAudioSource = audioSource[fearState]; break;
       }
   } */

    void OnTriggerEnter2D(Collider2D other) 
    {
        /** 
         *  This code only allow for one single play of audiosource.
         *
        if(other.gameObject.CompareTag("Player") && !played)
         {
             played = true;
             triggerAudioSource.Play();
             
         }
        **/

        triggerAudioSource.Play();

    }
    
}
