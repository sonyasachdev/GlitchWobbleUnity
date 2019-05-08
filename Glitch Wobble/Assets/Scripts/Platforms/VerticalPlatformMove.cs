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

        //Active Timer
        //Platform On
        if (isActive)
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
