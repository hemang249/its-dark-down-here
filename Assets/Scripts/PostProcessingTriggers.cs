using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingTriggers : MonoBehaviour
{
   public GameObject[] postProcVol;
    public GameObject FearPanel;
   private Fear fear;
   private int fearState;
   void Start()
   {
       fear = FearPanel.GetComponent<Fear>();
   }

   void Update()
   {
       fearState = (int)fear.currentState;
       SwitchProfile();
   }

   void SwitchProfile()
   {
       if(fearState > 0 && fearState < 4)
       {
           postProcVol[fearState].SetActive(true);
           postProcVol[fearState - 1].SetActive(false);
           postProcVol[fearState + 1].SetActive(false);
       }
       else if(fearState == 0)
       {
           postProcVol[fearState].SetActive(true);
           postProcVol[fearState + 1].SetActive(false);
       }
       else
       {
           postProcVol[fearState].SetActive(true);
           postProcVol[fearState - 1].SetActive(false);
       }
   }






}
