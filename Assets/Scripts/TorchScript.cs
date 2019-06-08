using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
   public Light Torch;
   [SerializeField] int numberOfTorches = 4;    // Number of torches player will spawn with
   public float torchLife = 5f;    // Time the torch will last 
   private bool isUsingTorch = false;

   
   void Start()
   {
       Torch.intensity = 0f;
   }

   void Update()
   {
       if( Input.GetKey(KeyCode.Space) && !isUsingTorch)
       {
            UseTorch();
            
       }    
   }

   void UseTorch()
   {
       
        Torch.intensity = 1f;
        isUsingTorch = true;
        Invoke("TorchTimer",torchLife);  // Destroy torch after specified Time
        TorchFlicker();
        numberOfTorches --;
   }

   void TorchTimer()
   {
       Torch.intensity = 0;
       isUsingTorch = false;
       // Destroy(Torch); Uncomment after adding Torch sprite
   }

   void TorchFlicker()
   {
       float flickerRange = Random.Range(15f , 20f);
       float intensity = Random.Range(0.5f , 2.5f);
       Torch.range = flickerRange;
       Torch.intensity = intensity;

       if(isUsingTorch)
           Invoke("TorchFlicker", 0.3f);
       else
           Torch.intensity = 0f;
   }
}
