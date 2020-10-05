using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedShiftMultiplier = 20.0f;
    public float downForce = -10.0f;

    private CharacterController _playerController;

    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        float deltaX = Input.GetAxis("Horizontal") * (speed * (Input.GetButtonDown("Shift") ? speedShiftMultiplier : 1));
        float deltaZ = Input.GetAxis("Vertical") * (speed * (Input.GetButtonDown("Shift") ? speedShiftMultiplier : 1));
        Vector3 pMove = new Vector3(deltaX, 0.0f, deltaZ);
        pMove = Vector3.ClampMagnitude(pMove, speed * speedShiftMultiplier);
        pMove.y = downForce; //Gravity
        pMove *= Time.deltaTime;
        pMove = transform.TransformDirection(pMove);
        _playerController.Move(pMove);
    }
}
