using UnityEngine;

public class RayIntersectionManager : MonoBehaviour
{
    [SerializeField] private RayLineRenderer rayLineRenderer1;
    [SerializeField] private RayLineRenderer rayLineRenderer2;
    [SerializeField] private GameObject intersectionMarker;

    void Update()
    {
        Vector3 start1 = rayLineRenderer1.startPointObject.transform.position;
        Vector3 dir1 = (rayLineRenderer1.directionPointObject.transform.position - start1).normalized;
        TestMyRay ray1 = new TestMyRay(start1, dir1);

        Vector3 start2 = rayLineRenderer2.startPointObject.transform.position;
        Vector3 dir2 = (rayLineRenderer2.directionPointObject.transform.position - start2).normalized;
        TestMyRay ray2 = new TestMyRay(start2, dir2);

        if (RayIntersectionCalculator.TryGetIntersection(ray1, ray2, out Vector3 intersection))
        {
            intersectionMarker.transform.position = intersection;
        }
    }
}