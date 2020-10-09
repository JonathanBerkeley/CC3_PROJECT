using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float speed = 5.0f;
    public float speedShiftMultiplier = 500.0f;
    [Range(0.0f, 100.0f)]
    public float jumpPower = 4.0f;
    public float downForce = -10.0f;
    public bool accelerateDownForce = false;

    private float velocityY = 0.0f;
    private float baseVelocityY;
    private float deltaY = 0.0f;
    private CharacterController _playerController;

    void Start()
    {
        baseVelocityY = velocityY;
        _playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxisRaw("Horizontal") * (speed * (Input.GetButtonDown("Shift") ? speedShiftMultiplier : 1));
        float deltaZ = Input.GetAxisRaw("Vertical") * (speed * (Input.GetButtonDown("Shift") ? speedShiftMultiplier : 1));
        if (accelerateDownForce && !_playerController.isGrounded)
            velocityY += downForce * Time.deltaTime;
        else if (accelerateDownForce && _playerController.isGrounded)
            velocityY = 0.0f; //Reset downforce on land
        /* WIP
        if (_playerController.isGrounded && Input.GetButton("Jump"))
        {
            deltaY += jumpPower;
            Debug.Log(deltaY);
        } 
        else
        {
            deltaY = 0.0f;
        }
        */
        Vector3 pMove = new Vector3(deltaX, deltaY, deltaZ);

        
        pMove.y = downForce + velocityY; //Gravity
        pMove *= Time.deltaTime;
        pMove = transform.TransformDirection(pMove);

        _playerController.Move(pMove);
    }
}
