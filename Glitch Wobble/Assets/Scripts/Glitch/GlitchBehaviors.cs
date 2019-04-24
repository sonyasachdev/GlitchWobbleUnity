using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchBehaviors : MonoBehaviour {

    //Lives
    int lives;


	// Use this for initialization
	void Start () {
        lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Hurt Method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Reduce GUI heart by one
            lives--;
            if(lives <= 0)
            {
                //Change to Gameover State
            }

            
        }
    }
}
