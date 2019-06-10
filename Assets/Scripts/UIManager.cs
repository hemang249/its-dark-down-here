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
        -Direction Arrow   
     */     
    
    [Header("Fear Timer UI")]
    public TextMeshProUGUI TimerText;

    [Header("Pause Menu UI")]
    public GameObject PauseMenuPanel;
    private bool isPaused = false;
    [Header("Torch Counter UI")]
    public TextMeshProUGUI TorchCounterText;

    
    [Header("Direction UI")]
    public Image DirectionArrow;
    public Transform Exit;

    [Header("DistanceCounter")]
    public TextMeshProUGUI DistanceText;

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
        isPaused = false;
        pc = Player.GetComponent<PlayerController>();
        ts = Player.GetComponent<TorchScript>();
        fs = FearPanel.GetComponent<Fear>(); 
    }

    void Update()
    {
        UpdateFearUI();
        UpdateTimer();
        UpdateTorchCounter();
        PauseMenu();
        DistanceCounter();
        //UpdateDirection();
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

    void UpdateDirection()
    {
        float relativeAngle = Vector3.Angle(Player.transform.position , Exit.position );
        DirectionArrow.rectTransform.rotation = Quaternion.Euler(0,0,relativeAngle);
    }

    void PauseMenu()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(!isPaused)
            {
                PauseMenuPanel.SetActive(true);
                Pause();
                isPaused = true;
            }
          
        }
    }

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Presed");

    }

    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Resumed");
    }

    public void GiveUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    void DistanceCounter()
    {
        float distance = Vector3.Distance(Player.transform.position , Exit.position);

        if(DistanceText != null)    // null safety    
            DistanceText.text = ((int)distance).ToString();
    }

}
