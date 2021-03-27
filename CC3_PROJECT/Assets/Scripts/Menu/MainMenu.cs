using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 
 //Upon loading into this scene it will always make the mouse cursor
 //viewable and movable
    void Start(){
            Pause.paused=false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

}

//This funstion makes it when it is clicked it will take the player to the next scene in the index order
public void PlayGame()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

}

//This function takes the player to the controls scene once clicked
public void Controls()
{
    SceneManager.LoadScene("Controls");

}

//this closes the game once clicked
public void QuitGame()
    {
        Application.Quit();
    }

}
