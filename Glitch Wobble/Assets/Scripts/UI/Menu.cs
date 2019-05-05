using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    Animator anim;
    GameObject glitchObject;
    GlitchBehaviors glitchScript;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        
        //Sets glitchScript to Behaviors
        glitchScript = glitchObject.GetComponent<GlitchBehaviors>();
    }

    private void Update()
    {
        //Game Over State
        if(glitchScript.Lives <= 0)
        {
            anim.SetTrigger("Game Over");
            Debug.Log("Game Over");
            Debug.Log(glitchScript.Lives + " Menu");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void RestartLevel()
    {
        //Reloads level
        Scene currentLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLevel.name);

        //Reinput Variables
    }
}
