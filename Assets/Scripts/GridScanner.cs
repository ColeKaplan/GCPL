using UnityEngine;
using Pathfinding; 
public class GridScanner : MonoBehaviour
{

    private float deltaTime;
    private Bounds bounds;
    void Start()
    {
        deltaTime = 0.0f;
        Vector3[] areaCorners = {
            new Vector3(-100, -100, 0),
            new Vector3(-100, 100, 0),
            new Vector3(100, 100, 0),
            new Vector3(100, -100, 0)
            };
        bounds = CalculateBounds(areaCorners);
    }

    void Update() {
        if (deltaTime >= 10) {
            AstarPath.active.UpdateGraphs(bounds);
            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
        
    }

    Bounds CalculateBounds(Vector3[] points)
    {
        if (points == null || points.Length == 0)
        {
            return new Bounds();
        }

        Vector3 min = points[0];
        Vector3 max = points[0];

        foreach (Vector3 point in points)
        {
            min = Vector3.Min(min, point);
            max = Vector3.Max(max, point);
        }

        Vector3 center = (min + max) / 2;
        Vector3 size = max - min;

        return new Bounds(center, size);
    }
}
