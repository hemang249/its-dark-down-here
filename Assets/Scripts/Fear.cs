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
    public float LocalDarkTime;
    public float GlobalDarkTime;

    [Space]
    [Header("UI")]
    private TimeSpan GlobalTimeSpan;    // Global Dark Time String Format
    private TimeSpan LocalTimeSpan;     // Local Dark Time String Format

    [Space]
    [Header("Fear Attributes")]
    public float fillAmount = 0f;
    public  float fearAmount;

    public enum FearState{
        NotTooScared,
        LittleScared,
        ModeratelyScared,
        VeryScared
    }

    public FearState currentState;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        currentState = FearState.NotTooScared;
        fearAmount = 0f;
        fillAmount = 0f;
    }

    void Update()
    {
        UpdateFear();
        UpdateFearState();
      
    }

    void UpdateFear()
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

    void UpdateFearState()
    {
        if(fillAmount <= 0.25f)
        {
            currentState = FearState.NotTooScared;
        }
        else if(fillAmount > 0.25f  && fillAmount <= 0.5f )
        {
            currentState = FearState.LittleScared;
        }
        else if(fillAmount > 0.5f  && fillAmount <= 0.75f )
        {
            currentState = FearState.ModeratelyScared;
        }
        else if(fillAmount > 0.75f  && fillAmount <= 1.0f)
        {
            currentState = FearState.VeryScared;
        }
    }

    
}
