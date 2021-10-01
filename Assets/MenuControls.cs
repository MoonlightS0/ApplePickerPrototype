using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControls : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("_Scene_1_Game");
        Debug.Log("Game pressed!");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
    public bool paused;                                   //Переменая для паузы игры.
    public void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))            //Нажатие на esc вызывает выход в меню
        {
            SceneManager.LoadScene("_Scene_0_MainMenu");                
            Debug.Log("Menu pressed!");
        }
        else if (Input.GetKeyDown(KeyCode.P))           //Нажатие на P вызывает паузу,имеется проблемы с активной корзиной во время паузы.
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