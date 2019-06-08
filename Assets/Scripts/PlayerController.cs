using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space]
    [Header("UI")]
    private TimeSpan GlobalTimeSpan;    // Global Dark Time String Format
    private TimeSpan LocalTimeSpan;     // Local Dark Time String Format


    [Header("Input Settings")]
    public int playerId; 

    [Header("Character Attributes")]
    [Range(0,15)]
    public float movementBaseSpeed = 5.0f;  // movement speed

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

    [Space]
    [Header("Triggers")]
    public bool inDark = false;     // To check if player is in dark
    public bool effectedByLight = true;     // To check if any Light is effecting plauyer

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();

        if(effectedByLight == false)
            inDark = true;
            
        if(inDark)
        {
            Debug.Log("In Dark");
            globalDarkTime += Time.deltaTime;
            localDarkTime += Time.deltaTime;
            // TODO: ADD SOME SORT OF EFFECT
        }
        else
        {
            Debug.Log("In Light");
            localDarkTime = 0;
            
        }

    }

    void OnGUI()
    {
        GlobalTimeSpan = TimeSpan.FromSeconds(globalDarkTime);
        LocalTimeSpan = TimeSpan.FromSeconds(localDarkTime);
        // Debug.Log(GlobalTimeSpan); UnComment to see how it will display
        // Add the GUI Update Code here

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

       if(movementDirection.y != 0)     // If moving along the  Y Axis , Play the Top Down Animation
       {
           animator.SetBool("isWalkingTopDown",true);
         
       }
       else
       {
           animator.SetBool("isWalkingTopDown",false);
       }
    }

}
