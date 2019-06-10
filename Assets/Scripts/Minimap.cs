using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform playerTransform;

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
