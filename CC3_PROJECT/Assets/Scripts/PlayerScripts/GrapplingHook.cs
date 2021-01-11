using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from following tutorial https://www.youtube.com/watch?v=Xgh4v1w5DxU
//SRC: Dani Devi
public class GrapplingHook : MonoBehaviour
{
    public LayerMask grapplableSurface;
    public Transform gunBarrel, gunCamera, player;

    private LineRenderer lineRenderer;
    private Vector3 grapplePosition;
    private float maxGrappleDistance = 125.0f;
    private SpringJoint springJoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        //StaticInput.UpdateStoppedShooting();

        if (Input.GetMouseButtonDown(0))
        {
            Grapple(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Grapple(false);
        }
    }

    private void LateUpdate()
    {
        DrawGrappleRope();
    }

    private void Grapple(bool enabled)
    {
        if (enabled)
        {
            RaycastHit hitLocation;
            if (Physics.Raycast(gunCamera.position, gunCamera.forward, out hitLocation, maxGrappleDistance, grapplableSurface))
            {
                grapplePosition = hitLocation.point;

                springJoint = player.gameObject.AddComponent<SpringJoint>();
                springJoint.autoConfigureConnectedAnchor = false;
                springJoint.connectedAnchor = grapplePosition;

                float distanceFromPoint = Vector3.Distance(player.position, grapplePosition);
                springJoint.maxDistance = distanceFromPoint * 0.8f;
                springJoint.minDistance = distanceFromPoint * 0.25f;

                springJoint.spring = 4.5f;
                springJoint.damper = 2.0f;
                springJoint.massScale = 400.5f;

                lineRenderer.positionCount = 2;
            }
        } 
        else
        {
            lineRenderer.positionCount = 0;
            Destroy(springJoint);
        }
    }

    private void DrawGrappleRope()
    {
        //Prevent drawing when not grappling
        if (!springJoint)
            return;

        lineRenderer.SetPosition(0, gunBarrel.position);
        lineRenderer.SetPosition(1, grapplePosition);
    }
}
