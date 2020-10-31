using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        PauseGame();
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #endif
        
        Application.Quit();
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        bool pause = Input.GetKeyDown(KeyCode.Escape) && isPaused == false;
        bool unPause = Input.GetKeyDown(KeyCode.Escape) && isPaused == true;

        if (pauseMenu.activeInHierarchy == true)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        if (pause)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
        else if (unPause)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
