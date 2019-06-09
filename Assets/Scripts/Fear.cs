using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fear : MonoBehaviour
{
    [Space]
    [Header("Player Statistics")]
    public GameObject Player;
    private float LocalDarkTime;
    private float GlobalLocalTime;

    [Space]
    [Header("Fear Attributes")]
    private Image fearBar;      
    private float fillAmount = 0f;
    public  float fearAmount;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
         
        fearBar = GetComponent<Image>();
        fearAmount = 0f;
        
        if(fearBar != null)     // To prevent a Null Refrence Exception
            fearBar.fillAmount = 0f;
    }

    void Update()
    {
        UpdateFearBar();
    }

    void UpdateFearBar()
    {
        // fetch values of Dark Time from PlayerControllerScript
        LocalDarkTime = Player.GetComponent<PlayerController>().localDarkTime; 
        GlobalLocalTime = Player.GetComponent<PlayerController>().globalDarkTime;

        fearAmount = LocalDarkTime;     

        if(fearBar != null)     // Null Reference Prevention
        {     
            if(LocalDarkTime != 0)      
                fearBar.fillAmount = fearAmount / 10f;      // Every 1 sec = 0.1 Fill of Bar
            else
                fearBar.fillAmount -= 0.005f;       // Decrease the bar once in light
        }
    }
}
