using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    //This function makes it so that when this scene is loaded it 
    //will always display the mouse cursor and make it movable
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Clicked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //The following functions will all take the player to the appropriate
    //scene once they are clicked
    public void PvP()
    {
        SceneManager.LoadScene(0);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void ObstacleCourse()
    {
        SceneManager.LoadScene("PvPCourse1");
        Time.timeScale = 1;
    }
    public void Sandbox()
    {
        SceneManager.LoadScene("Sandbox");
        Time.timeScale = 1;
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
