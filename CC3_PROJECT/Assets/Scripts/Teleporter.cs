using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
   
    public GameObject Player;//The variable for the teleporting player

//This function makes it so that when the player collides or "Enters
//this object it will instantly load the designated scene below and
//take the player there"
void OnTriggerEnter(Collider other) //sets the trigger for teleporter
{
    SceneManager.LoadScene("MainMenu");

}
}
