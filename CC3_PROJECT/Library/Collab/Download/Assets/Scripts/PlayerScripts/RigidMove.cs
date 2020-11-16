using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float shiftAcceleration = 15.0f;
    public float jumpHeight = 6.0f;
    public float groundedLeniancy = 0.1f;

    //Private things
    private float originalMoveSpeed;
    private Rigidbody _playerBody;
    private CapsuleCollider _playerCollider;
    private Vector3 playerScale;

    void Start()
    {
        originalMoveSpeed = moveSpeed;
        _playerBody = GetComponent<Rigidbody>();
        _playerCollider = GetComponent<CapsuleCollider>();
        playerScale = transform.localScale;
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
        
        /*
        //New movement, aimed to fix the movement through walls problem
        float xMagnitude;
        float yMagnitude;
        Vector2 pView = getViewOrientation();
        xMagnitude = pView.x;
        yMagnitude = pView.y;
        _playerBody.AddForce();
        _playerBody.AddForce();
        */
    }

    private bool isGrounded()
    {
        //This will draw an invisible ray downwards, if it hits an object, the player is grounded.
        return Physics.Raycast(transform.position, Vector3.down,
            _playerCollider.bounds.extents.y + groundedLeniancy);
    }
    /*
    private Vector2 getViewOrientation()
    {
        float lookAngle = orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }
    */
}
