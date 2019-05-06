using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlitchBehaviors : MonoBehaviour {

    //Lives
    protected int lives;

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    //Heart Images
    public Image heart1;
    public Image heart2;
    public Image heart3;

    //How long Glitch is unvulnerable when hurt
    public float invulTimer;

    //Attack Animation
    bool isAttacking;
    public float attackTimer;

    //Enemy
    //public GameObject enemy;

    //Animation
    protected Animator anim;

	// Use this for initialization
	void Start () {
        lives = 3;
        anim = GetComponent<Animator>();

        //Displays all Hearts   
        heart1.enabled = true;
        heart2.enabled = true;
        heart3.enabled = true;

        //Attack
        isAttacking = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Invulnerability Timer
        if (invulTimer < 3f && invulTimer > 0)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
            invulTimer -= Time.deltaTime;
        }
        if (invulTimer <= 0)
        {
            invulTimer = 3f;
            //End Animation
            anim.SetTrigger("hurt");
        }

        //Attack
        GlitchAttack();
        if (attackTimer < 1f && attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
        if(attackTimer <= 0f)
        {
            //Resets Time
            attackTimer = 1f;
            isAttacking = false;

            //End Animation
            anim.SetBool("isAttacking", false);
        }
    }

    //Trigger Method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Hurt Collide
        if (collision.gameObject.CompareTag("Enemy") && invulTimer >= 3f && isAttacking == false)
        {
            //Reduce GUI heart by one
            lives--;
            invulTimer -= Time.deltaTime;

            //Start Animation
            anim.SetTrigger("hurt");

            //Makes GUI Hearts Disappear
            if(heart1.enabled)
            {
                heart1.enabled = false;
            }
            else if(heart2.enabled)
            {
                heart2.enabled = false;
            }
            else
            {
                heart3.enabled = false;
            }

            if(lives < 0)
            {
                //Changes to Game Over Scene
                SceneManager.LoadScene("Game Over");
            }
        }

        //Attack Collide
        if(collision.gameObject.CompareTag("Enemy") && isAttacking == true)
        {
            Debug.Log("Attacked the Enemy");

            //Reduces Slime Life by 1
            if(collision.gameObject.GetComponent<HurtCollide>().lives > 0)
            {
                Debug.Log(collision.gameObject.GetComponent<HurtCollide>().lives);
                collision.gameObject.GetComponent<HurtCollide>().lives--;
            }
            else
            {
                //destroys enemy
                Destroy(collision.gameObject);
            }
            
        }

        //Finish Level
        if(collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("You Win");
        }

        //Death Zone
        if(collision.gameObject.CompareTag("Death Zone"))
        {
            /* Restart Level with lives lost
            if(lives > 0)
            {
                //Finds scene that you're on
                Scene currentLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentLevel.name);
                lives--;
            }
            else
            {
                SceneManager.LoadScene("Game Over");
            }*/
            
            //Ends Game when in Death Zone
            SceneManager.LoadScene("Game Over");
            
        }
    }

    //Attack Method
    private void GlitchAttack()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            //Set bool
            isAttacking = true;

            //Animation Start
            anim.SetBool("isAttacking", true);

            //Attack Timer
            attackTimer -= Time.deltaTime;

            Debug.Log("Attack");
        }
    }
}
