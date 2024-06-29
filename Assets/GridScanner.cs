using UnityEngine;
using Pathfinding; 
public class GridScanner : MonoBehaviour
{
    void Start()
    {
        
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
}
