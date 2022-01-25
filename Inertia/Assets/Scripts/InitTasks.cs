using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTasks : MonoBehaviour
{
    // General tasks to do at the start
    void Start()
    {
        Time.timeScale = 1;
        Pause.paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
