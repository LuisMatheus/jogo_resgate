using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassEnable : MonoBehaviour
{
    public float radius = 3f;
    public GameObject player;
    public GameObject phone;
    public GameObject compass;

    public CompassEnable(GameObject compass)
    {
        this.compass = compass;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey("e") && isClose(player))
        {
            compass.SetActive(true);
            phone.SetActive(false);   
        }
    }

    private bool isClose(GameObject player)
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= radius)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}

