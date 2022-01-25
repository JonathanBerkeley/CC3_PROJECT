using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMain : MonoBehaviour
{
    public float accelerationSpeed = 40.0f;
    public Transform grapplePointer;
    public Camera playerCam;
    public CharacterController player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit castHit)) {
                //Grapple attempt was valid
                grapplePointer.position = castHit.point;
                Vector3 grappleDirection = (castHit.point - transform.position).normalized;
                player.Move(grappleDirection * accelerationSpeed * Time.deltaTime);
            }
        }
    }
}
