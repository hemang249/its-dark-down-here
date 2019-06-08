using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    public int playerId; 

    [Header("Character Attributes")]
    [Range(0,15)]
    public float movementBaseSpeed = 5.0f;

    [Space]
    [Header("Character Statistics")]
    public Vector3 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("Refrences")]
    private Animator animator;
    private SpriteRenderer sr;

    [Space]
    [Header("Triggers")]
    public bool inDark = false;
    public bool effectedByLight = true;

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
            // TODO: ADD SOME SORT OF EFFECT
        }
        else
        {
            Debug.Log("In Light");
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
        Debug.Log(transform);
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
