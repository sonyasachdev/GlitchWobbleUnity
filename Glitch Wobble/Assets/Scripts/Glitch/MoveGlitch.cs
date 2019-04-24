﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGlitch : MonoBehaviour {

    Rigidbody2D glitchBody;

    //Movement
    public float speed;

    //Jump
    public float jumpPower;
    bool isJumping;

    // Use this for initialization
    void Start() {

        glitchBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        //Horizontal Movement
        float move = Input.GetAxis("Horizontal");
        glitchBody.velocity = new Vector2(move * speed, glitchBody.velocity.y);

        Jump();

        //Flipping Model
        Vector3 glitchScale = transform.localScale;
        if(move < 0)
        {
            glitchScale.x = 0.5f;
        }
        if(move > 0)
        {
            glitchScale.x = -0.5f;
        }

        transform.localScale = glitchScale;
	}

    void Jump()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;

            glitchBody.AddForce(new Vector2(glitchBody.velocity.x, jumpPower));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

            glitchBody.velocity = Vector2.zero;
        }

         if(collision.gameObject.CompareTag("MovingPlatform"))
        {
            isJumping = false;
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }
}
