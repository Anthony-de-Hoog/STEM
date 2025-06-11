using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMesh : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    Mesh mesh;
    
    Matrix2x2 matrix2x2 = new Matrix2x2();
    
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
        
        matrix2x2.matrix[0,0] = 1;
        matrix2x2.matrix[0,1] = 1;
        matrix2x2.matrix[1,1] = 1;
        
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrix2x2.MultiplyWithVector(vertices[i]);
        }
        mesh.vertices = vertices;

    }


    void Update()
    {
        
    }
}
