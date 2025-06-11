using UnityEngine;

public class RayIntersectionCalculator
{
    public static bool TryGetIntersection(TestMyRay ray1, TestMyRay ray2, out Vector3 intersection)
    {
        float a = ray1.directionPoint.x;
        float b = -ray2.directionPoint.x;
        float c = ray1.directionPoint.y;
        float d = -ray2.directionPoint.y;
        float det = a * d - b * c;

        if(Mathf.Abs(det) < Mathf.Epsilon)
        {
            intersection = Vector3.zero;
            return false;
        }

        Vector3 diff = ray2.startPoint - ray1.startPoint;
        float t = (diff.x * d - diff.y * b) / det;
        intersection = ray1.getPoint(t);
        return true;
    }
}