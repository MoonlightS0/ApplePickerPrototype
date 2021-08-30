using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControls : MonoBehaviour
{
    public void PlayPressed()                           //Turn on 1 scene.
    {
        SceneManager.LoadScene("_Scene_1_Game");
        Debug.Log("Game pressed!");
    }

    public void ExitPressed()                           //Close application
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
    public bool paused;                                   //Variable for pause game.
    public void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))            //Pressing esc causes the exit to the menu
        {
            SceneManager.LoadScene("_Scene_0_MainMenu");                
            Debug.Log("Menu pressed!");
        }
        else if (Input.GetKeyDown(KeyCode.P))           //Pressing P causes a pause,there are problems with the active bucket during the pause.
            if (!paused)
                        {
                            Time.timeScale = 0;
                            paused = true;
                        }
                    else
                    {
                    Time.timeScale = 1;
                    paused = false;
                    }
    }
}