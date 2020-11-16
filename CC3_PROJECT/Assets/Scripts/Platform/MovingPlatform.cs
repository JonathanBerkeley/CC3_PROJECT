using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class MovingPlatform : MonoBehaviour 
    {
    public Transform[] Waypoints;
    public float speed = 2.0f;
 
    public int CurrentPoint = 0;
    
    void Update () 
    {
        try
        {
            if (transform.position.y != Waypoints[CurrentPoint].transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
            }
        } 
        catch
        {
            Debug.Log("Problem code");
        }

        try
        {
            if (transform.position.y == Waypoints[CurrentPoint].transform.position.y)
            {
                ++CurrentPoint;
            }
        } 
        catch
        {
            Debug.Log("Problem code2");
        }

        if (CurrentPoint >= Waypoints.Length)
        {
            CurrentPoint = 0; 
        } 
     }
 }
