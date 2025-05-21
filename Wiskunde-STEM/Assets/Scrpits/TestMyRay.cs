using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyRay : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 directionPoint;
    public float lineParameter;

    public TestMyRay(Vector3 supportVector, Vector3 directionVector)
    {
        this.startPoint = supportVector;
        this.directionPoint = directionVector.normalized;
    }

    public Vector3 getPoint(float t)
    {
        return startPoint + directionPoint * t;
    }

    public Vector3 getBorderPoint(Vector2 min, Vector2 max)
    {
        float tx = float.MaxValue;
        float ty = float.MaxValue;

        if (Mathf.Abs(directionPoint.x) > 0.0001f)
        {
            tx = directionPoint.x > 0 ?
                (max.x - startPoint.x) / directionPoint.x :
                (min.x - startPoint.x) / directionPoint.x;
        }

        if (Mathf.Abs(directionPoint.y) > 0.0001f)
        {
            ty = directionPoint.y > 0 ?
                (max.y - startPoint.y) / directionPoint.y :
                (min.y - startPoint.y) / directionPoint.y;
        }

        return getPoint(Mathf.Min(tx, ty));
    }
}