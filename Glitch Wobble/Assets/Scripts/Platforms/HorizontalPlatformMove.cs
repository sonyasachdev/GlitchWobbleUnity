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

    //Active State
    private bool isActive;
    public float activeTimer;
    private float timeReset;
    public SpriteRenderer sprender;

    // Use this for initialization
    void Start()
    {
        isActive = true;
        timeReset = activeTimer;
        sprender = gameObject.GetComponent<SpriteRenderer>();
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

        //Active Timer
        //Platform On
        if(isActive)
        {
            if (activeTimer > 0)
            {
                activeTimer -= Time.deltaTime;
            }
            else
            {
                //Turns off Platform
                isActive = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                activeTimer = timeReset;


                //Turns off Sprite
                sprender.enabled = false;
                Debug.Log("active");


            }
        }
        //Platform Off
        else
        {
            if (activeTimer > 0)
            {
                
                activeTimer -= Time.deltaTime;
            }
            else
            {
                //Turns on Platform
                isActive = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
                activeTimer = timeReset;

                //Turns on Sprite
                sprender.enabled = true;
                Debug.Log("inactive");
            }
        }

    }
}
