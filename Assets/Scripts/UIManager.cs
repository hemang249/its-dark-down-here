// This script will take in values from GameManager and PlayerController to print to UI.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
     
    // Other scripts access this one through its public static methods.
    public TextMeshProUGUI fearTime;        //Text element showing time in dark

    /**
    public static void UpdateFearUI(float time)
    {
        // int minutes = (int)(time / 60);
        // float seconds = time % 60f;

        // current.fearTimeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        
        fearTime.text = PlayerController.globalDarkTime(time);
    }
    **/
    
}
