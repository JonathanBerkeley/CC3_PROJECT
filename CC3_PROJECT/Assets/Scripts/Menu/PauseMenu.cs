using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pause_Menu;

    // Start is called before the first frame update

    //This function makes it so that the mouse cursor is not viewable once the game loads in and also makes sure that
    //time is runnning which ensure that the player can move and interact with objects
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    // Update is called once per frame

    //This function constantly checks if the player pressed the p key and if they
    //did it will display the pause menu on the canvas, make the mouse cursor visible
    //and freeze time in the game so that the player and the world cannot move
    //or interact with anything, it also reverses all of these effects if the
    //player presses the p key again to remove the pause menu and allow the player
    // and world to once again move and interact
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P) && pause_Menu.activeInHierarchy == false)
        {
            pause_Menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else if (Input.GetKeyDown(KeyCode.P) && pause_Menu.activeInHierarchy == true)
        {

            Time.timeScale = 1;
            pause_Menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
        }

        //The following functions all function very similarly in that
        //if they are clicked with the cursor they will resume the game,
        //return the player to the main menu scene or exit the game entirely
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