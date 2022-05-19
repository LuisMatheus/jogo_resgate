using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Interactable : MonoBehaviour
{
    private float radius = 3f;
    public GameObject go1;
    public GameObject go2;

    private void Start()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        if (Input.GetKey("e"))
        {
            Instantiate(go1);
            Destroy(go2);
        }
    }
}
