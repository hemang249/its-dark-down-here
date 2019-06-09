using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fear : MonoBehaviour
{
    [Space]
    [Header("Player Statistics")]
    public GameObject Player;
    private float LocalDarkTime;
    private float GlobalDarkTime;

    [Space]
    [Header("UI")]
    public TextMeshProUGUI TimeText;
    private TimeSpan GlobalTimeSpan;    // Global Dark Time String Format
    private TimeSpan LocalTimeSpan;     // Local Dark Time String Format

    [Space]
    [Header("Fear Attributes")]
   
    public float fillAmount = 0f;
    public  float fearAmount;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
         
     
        fearAmount = 0f;
        fillAmount = 0f;
    }

    void Update()
    {
        UpdateFearBar();
        UpdateGUI();
    }

    void UpdateFearBar()
    {
        // fetch values of Dark Time from PlayerControllerScript
        LocalDarkTime = Player.GetComponent<PlayerController>().localDarkTime; 
        GlobalDarkTime = Player.GetComponent<PlayerController>().globalDarkTime;

        fearAmount = LocalDarkTime;     

         
        if(LocalDarkTime != 0)      
            fillAmount = fearAmount / 10f;      // Every 1 sec = 0.1 Fill of Bar
        else
            fillAmount -= 0.005f;       // Decrease the bar once in light
        
    }

     void UpdateGUI()
    {
        GlobalTimeSpan = TimeSpan.FromSeconds((int)GlobalDarkTime);
        LocalTimeSpan = TimeSpan.FromSeconds(LocalDarkTime);

        if(TimeText != null)
            TimeText.text = GlobalTimeSpan.ToString();       

    }
}
