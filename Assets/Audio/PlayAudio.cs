using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip collisionSound;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = collisionSound;
            audioSource.Play();
        }
    }
}
