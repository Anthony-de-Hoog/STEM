using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMesh : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    Mesh mesh;
    
    Vector3[] vertices;
    
    int[] triangles;
    void Start()
    {
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0.5f, 1, 0),
            new Vector3(1, 0, 0)
        };
        
        int[] triangles = new int[]
        {
            0, 1, 2
        };
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0.5f, 1),
            new Vector2(1, 0)
        };
        
        mesh.RecalculateNormals();

    }


    void Update()
    {
        
    }
}
