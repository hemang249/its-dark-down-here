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
    
    [Header("Fear Timer UI")]
    public TextMeshProUGUI TimerText;

    
    [Header("Torch Counter UI")]
    public TextMeshProUGUI TorchCounterText;


    [Header("Fear Bar UI")]
    public Image FearBar;
    private float fillAmount;
    private TimeSpan GlobalTimeSpan;

    [Header("Script References")]
    private PlayerController pc;
    private TorchScript ts;
    private Fear fs;



    [Header("GameObject References")]
    public GameObject Player;
    public GameObject FearPanel;


    void Start()
    {
        pc = Player.GetComponent<PlayerController>();
        ts = Player.GetComponent<TorchScript>();
        fs = FearPanel.GetComponent<Fear>(); 
    }

    void Update()
    {
        UpdateFearUI();
        UpdateTimer();
        UpdateTorchCounter();
    }

    void UpdateFearUI()
    {
        if(FearBar != null)     // For Preventing a Null Ref Exception
        {
            FearBar.fillAmount = fs.fillAmount;
        }
    }

    void UpdateTimer()
    {
         GlobalTimeSpan = TimeSpan.FromSeconds((int)(fs.GlobalDarkTime) );
         
        if(TimerText != null)   // null reference safety
            TimerText.text = GlobalTimeSpan.ToString();

    }

    void UpdateTorchCounter()
    {
        if(TorchCounterText != null)    // null references safety
            TorchCounterText.text = ts.numberOfTorches.ToString();
    }
  

}
