using UnityEngine;

public class CircumCircleDrawer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    
    public Transform pointS;
    
    public Transform pointMAB;
    public Transform pointMAC;
    public Transform pointMBC;

    public LineRenderer circleRenderer;
    public int circleSegments = 100;

    void Update()
    {
        Vector2 A = pointA.position;
        Vector2 B = pointB.position;
        Vector2 C = pointC.position;
        
        Vector2 mAB = (A + B) * 0.5f;
        Vector2 mAC = (A + C) * 0.5f;
        Vector2 mBC = (B + C) * 0.5f;
        
        if (pointMAB != null)
            pointMAB.position = mAB;
        if (pointMAC != null)
            pointMAC.position = mAC;
        if (pointMBC != null)
            pointMBC.position = mBC;
        
        Vector2 AB = B - A;
        Vector2 BC = C - B;
        Vector2 nAB = new Vector2(-AB.y, AB.x).normalized;
        Vector2 nBC = new Vector2(-BC.y, BC.x).normalized;

        Ray2D ray1 = new Ray2D(mAB, nAB);
        Ray2D ray2 = new Ray2D(mBC, nBC);

        if (GetRayIntersection(ray1, ray2, out Vector2 S))
        {
            if (pointS != null)
                pointS.position = S;

            float circumRadius = Vector2.Distance(S, A);
            DrawCircumCircle(S, circumRadius);
        }
    }

    bool GetRayIntersection(Ray2D r1, Ray2D r2, out Vector2 intersection)
    {
        Vector2 p = r1.origin;
        Vector2 r = r1.direction;
        Vector2 q = r2.origin;
        Vector2 s = r2.direction;
        float rxs = r.x * s.y - r.y * s.x;
        if (Mathf.Abs(rxs) < Mathf.Epsilon)
        {
            intersection = Vector2.zero;
            return false;
        }
        Vector2 q_p = q - p;
        float t = (q_p.x * s.y - q_p.y * s.x) / rxs;
        intersection = p + t * r;
        return true;
    }

    void DrawCircumCircle(Vector2 center, float radius)
    {
        circleRenderer.positionCount = circleSegments + 1;
        float angleStep = 360f / circleSegments;
        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            Vector2 pos = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            circleRenderer.SetPosition(i, pos);
        }
    }
}