using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float Speed = 5.0f;
    public float DownForce = -10.0f;

    private CharacterController _playerController;

    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;
        Vector3 pMove = new Vector3(deltaX, 0, deltaZ);
        pMove = Vector3.ClampMagnitude(pMove, Speed);
        pMove.y = DownForce; //Gravity
        pMove *= Time.deltaTime;
        pMove = transform.TransformDirection(pMove);
        _playerController.Move(pMove);
    }
}
