using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
  public  Animator TextBubbleAnimator;
    public GameObject TextBubble;
    public TextMeshProUGUI AdvanceText;
    private bool playItsDark = false;
    private bool exitAnim = false;
    private bool playWhereAmI = false;
    private GameObject Player;
    private PlayerController pc;

    private bool triggerStatue = false;
    public  Animator StatueAnimation;
    public GameObject Cake;
    private Animator CakeAnim;
    private bool collectCake = false;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CakeAnim = Cake.GetComponent<Animator>();
        pc = Player.GetComponent<PlayerController>();
      
    }
    void Update() 
    {
        if(!playWhereAmI && Input.anyKey)
        {
            playWhereAmI = true;
            TextBubbleAnimator.SetBool("playWhereAmI",playWhereAmI);
            Invoke("DelayItsDark",0.5f);
        }

        if(playItsDark && Input.anyKey)
        {
            playItsDark = true;
            TextBubbleAnimator.SetBool("playItsDark",playItsDark);
            Invoke("DelayExit",0.5f);
        }

        if(exitAnim && Input.anyKey)
        {
            exitAnim = true;
            TextBubbleAnimator.SetBool("exitAnim",exitAnim);
            pc.ableToMove = true;
            Destroy(AdvanceText);
            Destroy(TextBubble);
            
        
        }


    }
    
    
    void DelayItsDark()
    {
        playItsDark = true;
    }

    void DelayExit()
    {
        exitAnim = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Statue"))
        {
            triggerStatue = true;
            StatueAnimation.SetBool("triggerStatue",triggerStatue);
        }

        if(other.gameObject.CompareTag("Cake"))
        {
         
            collectCake = true;
          
            CakeAnim.SetBool("collectCake",collectCake);
           
        }    
    }

}
