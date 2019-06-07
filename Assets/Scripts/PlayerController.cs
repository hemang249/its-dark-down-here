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

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();

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
       transform.position += movementBaseSpeed * movementDirection * Time.deltaTime;

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
