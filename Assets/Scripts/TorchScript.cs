using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
   public Light Torch;

   
   void Start()
   {
       TorchFlicker();
   }

   void TorchFlicker()
   {
       float flickerRange = Random.Range(15f , 20f);
       float intensity = Random.Range(0.5f , 2.5f);
       Torch.range = flickerRange;
       Torch.intensity = intensity;
       Invoke("TorchFlicker", 0.5f);
   }
}
