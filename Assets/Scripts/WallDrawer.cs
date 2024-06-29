using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallDrawer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wall;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), wall);
        }
    }
}
