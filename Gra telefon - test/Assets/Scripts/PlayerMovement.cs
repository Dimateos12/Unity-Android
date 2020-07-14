using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;

    private int xMove = 0;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {   

        if (Input.GetKeyDown("left") && xMove > -2)
        {
            xMove -= 2;
            playerTransform.position = new Vector2(xMove, playerTransform.position.y);
        }

        if (Input.GetKeyDown("right") && xMove < 2)
        {
            xMove += 2;
            playerTransform.position = new Vector2(xMove, playerTransform.position.y);
        }
        
    }
}
