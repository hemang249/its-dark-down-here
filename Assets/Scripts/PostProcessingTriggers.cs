using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingTriggers : MonoBehaviour
{
   public PostProcessProfile[] postProcProf;
   private PostProcessProfile currentProf;
   public PostProcessVolume postProcVol;
   public GameObject FearPanel;
   private Fear fear;
   private int fearState;
   void Start()
   {
       fear = FearPanel.GetComponent<Fear>();
       currentProf = postProcVol.GetComponent<PostProcessProfile>();
   }

   void Update()
   {
       fearState = (int)fear.currentState;
       SwitchProfile();
   }

   void SwitchProfile()
   {
       currentProf = postProcProf[fearState];
   }






}
