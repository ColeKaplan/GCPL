using UnityEngine;
using Pathfinding; 
public class GridScanner : MonoBehaviour
{

    private float deltaTime;
    void Start()
    {
        deltaTime = 0.0f;
        if (AstarPath.active != null)
        {
           
            AstarPath.active.Scan();
            Debug.Log("A* Grid Scanned Automatically.");
        }
        else
        {
            Debug.LogError("AstarPath object is not active or initialized.");
        }
    }

    void Update() {
        if (deltaTime >= 30) {
            AstarPath.active.Scan();
            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
        
    }
}
