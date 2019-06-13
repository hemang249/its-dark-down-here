using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadingScreen : MonoBehaviour
{
   private string[] loadingText = new string[3] {"Loading.","Loading..","Loading..."};
   public TextMeshProUGUI LoadingText;

   void Start()
   {
     FirstFrame();
     Invoke("Load",1.5f);
   }

   void FirstFrame()
   {
       if(LoadingText != null)
        LoadingText.text = loadingText[0];
       Invoke("SecondFrame",0.5f);
   }

   void SecondFrame()
   {
       if(LoadingText != null)
        LoadingText.text = loadingText[1];
       Invoke("ThirdFrame",0.5f);
   }

   void ThirdFrame()
   {
       if(LoadingText != null)
            LoadingText.text = loadingText[2];
        Invoke("FirstFrame",0.5f);
   }

   void Load()
   {
       SceneManager.LoadScene("Level1");
   }


}
