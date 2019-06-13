using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;   // Movement Speed
    private Animator animator;
    private bool isWalking = false;    // bool trigger for Walking Animation


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 xDir = new Vector3(xInput , 0 , 0);
        Vector3 yDir = new Vector3(0 , yInput , 0);   

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.position += yDir * moveSpeed * Time.deltaTime;
            isWalking = true;
            animator.SetBool("isWalking", isWalking);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            transform.position += xDir * moveSpeed * Time.deltaTime;
            // TODO : ADD SIDEWAYS ANIMATION
        }
        else
        {
            isWalking = false;
            animator.SetBool("isWalking",isWalking);
        }
    }
}
