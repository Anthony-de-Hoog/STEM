using UnityEngine;

public class Matrix2x2
{
    public float m00, m01, m10, m11;

    public float[,] matrix = new float[2, 2];
    
    public Matrix2x2()
    { 
        matrix[0, 0] = 1;
        matrix[0, 1] = 0;
        matrix[1, 0] = 0;
        matrix[1, 1] = 1;
    }
    
    public void UpdateMatrix()
    {
        matrix[0, 0] = m00;
        matrix[0, 1] = m01;
        matrix[1, 0] = m10;
        matrix[1, 1] = m11;
    }

    public Vector3 MultiplyWithVector(Vector3 v)
    {
        Vector3 ans;
        ans.x = matrix[0, 0] * v.x + matrix[0, 1] * v.y;
        ans.y = matrix[1, 0] * v.x + matrix[1, 1] * v.y;
        ans.z = 0;
        return ans;
    }
    
}
