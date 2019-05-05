using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchBehaviors : MonoBehaviour {

    //Lives
    protected int lives;

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    //How long Glitch is unvulnerable when hurt
    public float invulTimer;

    //Animation
    protected Animator anim;

	// Use this for initialization
	void Start () {
        lives = 3;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (invulTimer < 3f && invulTimer > 0)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
            invulTimer -= Time.deltaTime;
        }
        if (invulTimer <= 0)
        {
            invulTimer = 3f;
            //End Animation
            anim.SetBool("isHurt", false);
        }

       

    }

    //Hurt Method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && invulTimer >= 3f)
        {
            //Reduce GUI heart by one
            lives--;
            invulTimer -= Time.deltaTime;

            //Start Animation
            anim.SetBool("isHurt", true);

            Debug.Log("collided");
            Debug.Log(lives + " Glitch");
        }
    }
}
