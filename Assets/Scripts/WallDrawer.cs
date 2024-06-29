using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemap;

public class WallDrawer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wall;
    public List<GameObject> walls;
    public Transform tileGridUI;


    // Start is called before the first frame update
    void Start()
    {
        GameObject UITile = new GameObject("UI Tile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
