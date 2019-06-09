using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorchScript : MonoBehaviour
{
    
    private GameObject player;
    private PlayerController pc;

   
   [Space]
   [Header("UI")]
   public TextMeshProUGUI torchCounterText;

   [Space]
   [Header("Torch Attributes")]
   public Light Torch;
   [SerializeField] int numberOfTorches = 4;    // Number of torches player will spawn with
   public float torchLife = 5f;    // Time the torch will last 
   private bool isUsingTorch = false;

   
   void Start()
   {
       Torch.intensity = 0f;
       player = GameObject.FindGameObjectWithTag("Player");
       pc = player.GetComponent<PlayerController>();
   }

   void Update()
   {
       UpdateGUI();
       
       if( Input.GetKey(KeyCode.Space) && !isUsingTorch && numberOfTorches != 0)
       {
            pc.effectedByLight = true;
            pc.inDark = false;
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
       pc.effectedByLight = false;
        pc.inDark = true;
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
        // TODO Vary Colour Of The torch light between two values
       
       if(isUsingTorch)
           Invoke("TorchFlicker", 0.5f);
       else
           Torch.intensity = 0f;
   }

   void UpdateGUI()
   {
       if(torchCounterText != null)
       {
           torchCounterText.text =  numberOfTorches.ToString();
       }
   }
}
