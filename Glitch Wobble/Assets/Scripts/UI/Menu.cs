using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    
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
        //Reloads Current Level
        /*
        Scene currentLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLevel.name);*/

        //Hard Code
        SceneManager.LoadScene("Level 1");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
