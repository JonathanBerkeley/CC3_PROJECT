using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float toPoint;
    public float fromPoint;

    public bool progressOnX;
    public bool progressOnY;
    public bool progressOnZ;

    public float speed = 2.0f;

    private Vector3 currentPos;
    void Update()
    {
        if (progressOnX)
        {
            if (transform.position.x < toPoint)
            {
                currentPos = transform.position;
                currentPos.x += speed * Time.deltaTime;
                transform.position = currentPos;
            }
        }
        else if (progressOnY)
        {

        }
        else if (progressOnZ)
        {

        }
    }
}
