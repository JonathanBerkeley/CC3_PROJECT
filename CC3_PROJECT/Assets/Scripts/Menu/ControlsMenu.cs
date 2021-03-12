using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

  public void Back()
{
    SceneManager.LoadScene("MainMenu");

}
}
