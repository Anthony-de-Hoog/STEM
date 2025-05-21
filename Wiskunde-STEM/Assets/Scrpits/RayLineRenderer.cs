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
        
        Vector3 startPos = startPointObject.transform.position;
        
        Vector3 directionVector = (directionPointObject.transform.position - startPos).normalized;

        
        TestMyRay myRay = new TestMyRay(startPos, directionVector);
        Vector3 endPos = myRay.getPoint(lineLength);

       
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}