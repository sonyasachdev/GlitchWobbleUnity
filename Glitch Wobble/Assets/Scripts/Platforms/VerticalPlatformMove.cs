using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMove : MonoBehaviour {


    //Movement Check
    public bool moveUp;

    //Platform Speed
    float dirY;
    public float moveSpeed;

    //Bounds
    public float upBound;
    public float downBound;

    // Use this for initialization
    void Start()
    {
        //Makes platform start moving up
    }

    // Update is called once per frame
    void Update()
    {
        //Setting Bounds
        if (transform.position.y > upBound)
        {
            moveUp = false;
        }
        if (transform.position.y < downBound)
        {
            moveUp = true;
        }

        //Movement Scripts
        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

    }
}
