using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMove : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    public float shiftAcceleration = 15.0f;
    public float jumpHeight = 6.0f;
    public float groundedLeniancy = 0.1f;

    private float originalMoveSpeed;
    private Rigidbody _playerBody;
    private CapsuleCollider _playerCollider;
    void Start()
    {
        originalMoveSpeed = moveSpeed;
        _playerBody = GetComponent<Rigidbody>();
        _playerCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        

        if (isGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Player jump by adding vertical force, accounting for player mass.
                _playerBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }

            if (Input.GetButton("Shift"))
            {
                moveSpeed = shiftAcceleration;
            } 
            else
            {
                moveSpeed = originalMoveSpeed;
            }
        }

        float hMove = Input.GetAxis("Horizontal") * moveSpeed;
        float vMove = Input.GetAxis("Vertical") * moveSpeed;
        hMove *= Time.deltaTime;
        vMove *= Time.deltaTime;

        transform.Translate(hMove, 0, vMove);
    }

    private bool isGrounded()
    {
        //This will draw an invisible ray downwards, if it hits an object, the player is grounded.
        return Physics.Raycast(transform.position, Vector3.down,
            _playerCollider.bounds.extents.y + groundedLeniancy);
    }
}
