using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticeCollector : MonoBehaviour
{

    public Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        var meshFilter = this.gameObject.GetComponent<MeshFilter>();
        var mesh = meshFilter.mesh;
        this.vertices = mesh.vertices;
    }

}
