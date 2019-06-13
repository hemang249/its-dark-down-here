using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
   

    [Header("Input Settings")]
    public int playerId; 

    [Header("Character Attributes")]
    [Range(0,15)]
    public float movementBaseSpeed = 5.0f;  // movement speed

    private bool backIdle = false;
    private bool forwardIdle = false;
    public TextMeshProUGUI CompleteText;
    private bool walkForward = false;
    private bool walkBackward = false;


    [Space]
    [Header("Character Statistics")]
    public Vector3 movementDirection;
    public float movementSpeed;
    public float globalDarkTime = 0;
    public float localDarkTime = 0;

    [Space]
    [Header("Refrences")]
    private Animator animator;  // Ref to Animator attatch to player
    private SpriteRenderer sr;  // Ref to SpriteRenderer attatch to player
    private TorchScript ts;

    [Space]
    [Header("Triggers")]
    public bool inDark = false;     // To check if player is in dark
    public bool effectedByLight = true;     // To check if any Light is effecting plauyer
    public bool ableToMove = false;

    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponent<TorchScript>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ableToMove)
        {
            ProcessInputs();
            Move();
        }    

        if(effectedByLight == false)
            inDark = true;
            
        if(inDark)
        {
            
            globalDarkTime += Time.deltaTime;
            localDarkTime += Time.deltaTime;
            // TODO: ADD SOME SORT OF EFFECT
        }
        else
        {
           
            localDarkTime = 0;
            
        }

    }


    void ProcessInputs()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        movementDirection = new Vector3(xAxis, yAxis  , 0);
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

    }

    void Move()
    {
       transform.position += movementBaseSpeed * movementDirection * Time.deltaTime;    // Using Transform based for simpler outcomes instead of using rigid body and complicating movement

       if(movementDirection.x == 0 && movementDirection.y == 0 )
       {
           walkForward = false;
           animator.SetBool("walkForward",walkForward);
           walkBackward = false;
           animator.SetBool("walkBackward",walkBackward);
           backIdle = true;
           animator.SetBool("backIdle",backIdle);
         
       }

       if(movementDirection.y > 0)     // If moving along the  Y Axis , Play the Top Down Animation
       {
           backIdle = false;
           animator.SetBool("backIdle",backIdle);
          walkBackward = false;
          animator.SetBool("walkBackward",walkBackward);
          walkForward = true;
          animator.SetBool("walkForward",walkForward);
         
       }
       else if(movementDirection.y < 0)
       {
           walkForward = false;
           animator.SetBool("walkForward",walkForward);
           backIdle = false;
           animator.SetBool("backIdle",backIdle);
           walkBackward = true;
           animator.SetBool("walkBackward",walkBackward);
       }

       if(movementDirection.x < 0)
       {
           sr.flipX = false;
         

       }
       else if(movementDirection.x > 0)
       {
           sr.flipX = true;
           
       }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "CollectibleTorch")
        {
            ts.numberOfTorches ++;
            Destroy(other.gameObject);
        }        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Throne")
        {
            ableToMove = false;
            CompleteText.text = "CONGRATULATIONS ON EXITING THE CAVE!";
            Invoke("RollCredits",5f);
        }    
    }

    void RollCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

   
    
}
