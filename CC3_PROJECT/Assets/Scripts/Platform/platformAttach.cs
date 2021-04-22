using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour
{
  public GameObject Platform;
  public GameObject Player;


//This function will make the player character a child of the 
//moving platform as long as it is touching the areaon top of it
  void OnTriggerEnter () {

Player.transform.parent = Platform.transform;

  }

  //This will remove the child role from the player once they exit
  //the area moving platform so they don't continue to move along
  //with the platform
  void OnTriggerExit () {
  Player.transform.parent = null;
 }
}
