using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;
    public Vector3 offsetPosition;


    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offsetPosition;
        // Use mult smoothSpeed * DeltaTime for smooth transitions -> has to increase speed.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.Rotate(new Vector3(0, target.rotation.y, 0));

        // LookAt -> direct at at object's center, in a full avatar with joints has to pickup another reference like a "neck". 
        //transform.LookAt(target);
    }
}