using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject pauseMenu;

    public bool isPaused = false;

 

   void Update()
   {
       if(Input.GetButtonDown("Cancel"))
       {
           if(isPaused == false)
           {
               Time.timeScale = 0;
               isPaused = true;
               Cursor.visible = true;
               pauseMenu.SetActive(true);
           }
           else
           {
               pauseMenu.SetActive(false);
               Cursor.visible = false;
               isPaused = false;
               Time.timeScale = 1;
           }
       }
       

   }
    public void ResumeGame()
    {
               pauseMenu.SetActive(false);
               Cursor.visible = false;
               isPaused = false;
               Time.timeScale = 1;   
    }
        
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
