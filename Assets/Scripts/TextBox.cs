using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public  Animator TextBubbleAnimator;
    public GameObject TextBubble;
    private bool playWhatHappened = false;
    private bool exitAnim = false;
    private bool playWhereAmI = false;
    private GameObject Player;
    private PlayerController pc;

    private bool triggerStatue = false;
    public  Animator StatueAnimation;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pc = Player.GetComponent<PlayerController>();
      
    }
    void Update() 
    {
        if(!playWhatHappened && Input.GetKey(KeyCode.Mouse0))
        {
            playWhatHappened = true;
            TextBubbleAnimator.SetBool("playWhatHappened",playWhatHappened);
            Invoke("DelayWhereAmI",1f);
        }

        if(playWhereAmI && Input.GetKey(KeyCode.Mouse0))
        {
            playWhereAmI = true;
            TextBubbleAnimator.SetBool("playWhereAmI",playWhereAmI);
            Invoke("DelayExit",1f);
        }

        if(exitAnim && Input.GetKey(KeyCode.Mouse0))
        {
            exitAnim = true;
            TextBubbleAnimator.SetBool("exitAnim",exitAnim);
            pc.ableToMove = true;
            Destroy(TextBubble);
        
        }


    }
    
    
    void DelayWhereAmI()
    {
        playWhereAmI = true;
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
    }

}
