using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatformMove : MonoBehaviour {

    //Movement Check
    public bool moveRight;

    //Platform Speed
    float dirX;
    public float moveSpeed;

    //Platform Bounds
    public float rightBound;
    public float leftBound;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Setting Bounds
        if (transform.position.x > rightBound)
        {
            moveRight = false;
        }
        if (transform.position.x < leftBound)
        {
            moveRight = true;
        }

        //Movement Scripts
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

    }
}
