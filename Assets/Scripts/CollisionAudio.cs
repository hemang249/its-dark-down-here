using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
   private AudioSource audioSource;

   void Start()
   {
       audioSource = GetComponent<AudioSource>();

   }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            audioSource.Play();
    }
}
