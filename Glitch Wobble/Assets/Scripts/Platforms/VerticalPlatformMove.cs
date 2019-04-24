using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMove : MonoBehaviour {


    //Movement Check
    bool moveUp = true;

    //Platform Speed
    float dirY, moveSpeed = 3f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Setting Bounds
        if (transform.position.y > 4f)
        {
            moveUp = false;
        }
        if (transform.position.y < -4f)
        {
            moveUp = true;
        }

        //Movement Scripts
        if (moveUp)
        {
            transform.position = new Vector2(transform.position.y + moveSpeed * Time.deltaTime, transform.position.x);
        }
        else
        {
            transform.position = new Vector2(transform.position.y - moveSpeed * Time.deltaTime, transform.position.x);
        }

    }
}
