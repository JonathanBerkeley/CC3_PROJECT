using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour
{
  public GameObject Platform;
  public GameObject Player;

  void OnTriggerEnter () {

Player.transform.parent = Platform.transform;

  }
  void OnTriggerExit () {
  Player.transform.parent = null;
 }
}
