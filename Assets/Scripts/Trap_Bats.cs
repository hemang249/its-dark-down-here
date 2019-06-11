using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Bats : MonoBehaviour
{

    public AudioSource batSound;
    public ParticleSystem batParticles;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        batSound.Play();
        batParticles.Play();
        
    }
}
