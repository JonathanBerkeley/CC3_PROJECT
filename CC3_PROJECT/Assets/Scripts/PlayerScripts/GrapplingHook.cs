using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from following tutorial https://www.youtube.com/watch?v=Xgh4v1w5DxU
//SRC: Dani Devi
public class GrapplingHook : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplePosition;
    
    public LayerMask grapplableSurface;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
    }
}
