using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

   void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 playerPos = transform.position;

        playerPos.x = playerTransform.position.x;
        playerPos.y = playerTransform.position.y;

        transform.position = playerPos;

    }
}
