using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    // Start is called before the first frame update

    //This function makes it so that when this scene opens 
    //it will always make the mouse movable and visible
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

  //This function makes it so that when the button is clicked it will
  //take the player back to the main menu screen
  public void Back()
{
    SceneManager.LoadScene("MainMenu");

}
}
