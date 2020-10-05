using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Look : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis Axis = RotationAxis.MouseX;

    public float MinimumVertical = -45.0f;
    public float MaximumVertical = 45.0f;

    public float HorizonitalSensitivity = 3.0f;
    public float VerticalSensitivity = 3.0f;
    
    private float _rotationX = 0.0f;

    void Update()
    {
        //For X
        if(Axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * HorizonitalSensitivity, 0);
        } 
        //For Y
        else if (Axis == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * VerticalSensitivity;
            _rotationX = Mathf.Clamp(_rotationX, MinimumVertical, MaximumVertical);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
