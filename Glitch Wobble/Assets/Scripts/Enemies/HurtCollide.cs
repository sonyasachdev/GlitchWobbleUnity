using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCollide : MonoBehaviour {

    //Movement Check
    bool moveRight;

    //Platform Speed
    float dirX, moveSpeed = 2f;

    //Platform Bounds
    public float rightBound;
    public float leftBound;

    //Lives
    public int lives;

    // Use this for initialization
    void Start()
    {
        moveRight = true;
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

        Vector3 enemyScale = transform.localScale;
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            if(enemyScale.x > 0)
            {
                enemyScale.x *= -1f;
            }
            
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            if(enemyScale.x < 0)
            {
                enemyScale.x *= -1f;
            }
        }

        transform.localScale = enemyScale;

    }

}



