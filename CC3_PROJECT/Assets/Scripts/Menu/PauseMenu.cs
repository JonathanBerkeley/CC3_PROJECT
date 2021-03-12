using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pause_Menu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P) && pause_Menu.activeInHierarchy == false)
        {
            pause_Menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
         else if ( Input.GetKeyDown(KeyCode.P) && pause_Menu.activeInHierarchy == true)
        {

            Time.timeScale = 1;
            pause_Menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
        }


    }
    public void ResumeGame()
    {
               pause_Menu.SetActive(false);
               Cursor.visible = false;
               Time.timeScale = 1;
    }
    public void GoToMainMenu()
    {
        
SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    }