using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetectionScript : MonoBehaviour
{
    public GameObject player;
    private PlayerController pc;
    private bool playerInRange = true;

    [Space]
    [Header("Ray Casting Attributes")]
    private Ray ray;
    private RaycastHit hit;
    private float rayLength = 5f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }
    void Update() 
    {  
        
        float distance = Vector2.Distance(transform.position , player.transform.position);

        if(playerInRange || distance <= rayLength)
        {   
            if(distance <= rayLength)
            {
                pc.effectedByLight = true;
                pc.inDark = false;
                CheckLightDetection();
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
                pc.effectedByLight = false;
                
            }
        }
        
       
    }

    void CheckLightDetection()
    {
        Vector2 rayDir = new Vector2(player.transform.position.x , player.transform.position.y);
      
        RaycastHit2D hit = Physics2D.Raycast(transform.position , rayDir , rayLength);

        if(hit.collider != null)
        {
            if(hit.collider.tag == "Player")
            {
               pc.inDark = false;
               
              
            
            }
         
        }
    }
    
 
}
