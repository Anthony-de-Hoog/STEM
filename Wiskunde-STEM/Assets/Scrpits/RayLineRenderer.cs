using UnityEngine;

public class RayLineRenderer : MonoBehaviour
{
    [SerializeField] public GameObject startPointObject;
    [SerializeField] public GameObject directionPointObject;
    public float lineLength = 100f;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Vector3 pointA = startPointObject.transform.position;
        Vector3 pointB = directionPointObject.transform.position;
        Vector3 midPoint = (pointA + pointB) * 0.5f;
        Vector3 direction = (pointB - pointA).normalized;
        float halfLength = lineLength * 0.5f;

        Vector3 startPos = midPoint - direction * halfLength;
        Vector3 endPos = midPoint + direction * halfLength;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}