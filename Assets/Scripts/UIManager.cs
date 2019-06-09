using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /*  FOLLOWING UI HANDLED HERE
        
        -FEAR BAR 
        -TORCH COUNTER
        -DARK TIME DISPLAY    
     */     
   
    [Header("Fear Bar UI")]
    public Image FearBar;
    private float fillAmount;
    private TimeSpan GlobalTimeSpan;

    [Header("Script References")]
    private PlayerController pc;
    private Fear fs;



    [Header("GameObject References")]
    public GameObject Player;
    public GameObject FearPanel;


    void Start()
    {
        pc = Player.GetComponent<PlayerController>();
        fs = FearPanel.GetComponent<Fear>(); 
    }

    void Update()
    {
        UpdateFearUI();
    }

    void UpdateFearUI()
    {
        if(FearBar != null)     // For Preventing a Null Ref Exception
        {
            FearBar.fillAmount = fs.fillAmount;
        }
    }
  

}
