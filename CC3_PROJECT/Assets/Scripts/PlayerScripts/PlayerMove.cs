using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float speed = 5.0f;
    [Range(0.0f, 100.0f)]
    public float jumpPower = 4.0f;
    public float downForce = -10.0f;
    public bool accelerateDownForce = false;

    private Vector3 playerVelocity;
    private bool playerGrounded;
    private CharacterController _playerController;
    
    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerGrounded = _playerController.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0.0f;
        }
        
        float deltaX = Input.GetAxisRaw("Horizontal") * speed;
        float deltaZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 pMove = new Vector3(deltaX, 0.0f, deltaZ);

        pMove = transform.TransformDirection(pMove);
        _playerController.Move(pMove * Time.deltaTime);

        if (accelerateDownForce && !_playerController.isGrounded)
            playerVelocity.y += downForce * Time.deltaTime;
        else if (accelerateDownForce && _playerController.isGrounded)
            playerVelocity.y = 0.0f;

        if (playerGrounded && Input.GetButton("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpPower * -3.0f * downForce);
        }
        playerVelocity.y += downForce * Time.deltaTime;
        _playerController.Move(playerVelocity * Time.deltaTime);
    }
}
