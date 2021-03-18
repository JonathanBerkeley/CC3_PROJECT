using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
       void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

  public void PvP()
{
    SceneManager.LoadScene("MenuScene");

}

  public void ObstacleCourse()
{
    SceneManager.LoadScene("PvPCourse1");

}
public void Sandbox()
{
    SceneManager.LoadScene("Sandbox");

}
 public void Back()
{
    SceneManager.LoadScene("MainMenu");

}
}
