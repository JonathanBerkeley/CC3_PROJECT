using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedShiftMultiplier = 500.0f;
    public float downForce = -10.0f;
    public bool accelerateDownForce = false;

    private float velocityY = 0.0f;

    private CharacterController _playerController;

    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxisRaw("Horizontal") * (speed * (Input.GetButtonDown("Shift") ? speedShiftMultiplier : 1));
        float deltaZ = Input.GetAxisRaw("Vertical") * (speed * (Input.GetButtonDown("Shift") ? speedShiftMultiplier : 1));
        Vector3 pMove = new Vector3(deltaX, 0.0f, deltaZ);

        if (accelerateDownForce && !_playerController.isGrounded)
            velocityY += downForce * Time.deltaTime;
        pMove.y = downForce + velocityY; //Gravity
        pMove *= Time.deltaTime;
        pMove = transform.TransformDirection(pMove);

        _playerController.Move(pMove);
    }
}
