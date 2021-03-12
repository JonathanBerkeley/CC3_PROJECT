using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //public Transform teleportTarget;//this is the variable for the teleport position
    public GameObject Player;//The variable for the teleporting player

void OnTriggerEnter(Collider other) //sets the trigger for teleporter
{
    SceneManager.LoadScene("MainMenu");

}
}
