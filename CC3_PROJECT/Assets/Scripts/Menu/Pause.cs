using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    public static bool paused = false;
    public GameObject pauseUI;
    public GameObject crosshair;


    private void Start()
    {
        //Make this a singleton class
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {    //resumes game
                pauseUI.SetActive(false);
                crosshair.SetActive(true);
                Time.timeScale = 1;
                paused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pauseUI.SetActive(true);    //pauses game
                crosshair.SetActive(false);
                Time.timeScale = 0;
                paused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        StopAllCoroutines();
        MiscInputListener.DisconnectBackToMenu();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
