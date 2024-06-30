using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallDrawer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] walls; // Ordering of this matters a lot. Up = 1, Down = 2, Left = 4, Right = 8. Add them up and use that position in the array
    public int wallRemovals = 10;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilemapPosition = tilemap.WorldToCell(position);
            int wallNum = calculateWallSurroundings(tilemapPosition);
            tilemap.SetTile(tilemapPosition, walls[wallNum]);
            updateNeighbors(tilemapPosition);
        }
        if(Input.GetMouseButton(1) && wallRemovals > 0) {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilemapPosition = tilemap.WorldToCell(position);
            if(tilemap.GetTile(tilemapPosition) != null) {
                tilemap.SetTile(tilemapPosition, null);
                wallRemovals--;
                updateNeighbors(tilemapPosition);
            }
        }
    }

    private int calculateWallSurroundings(Vector3Int pos){
        int wallNum = 0;
        if(tilemap.GetTile(pos + new Vector3Int(0,1,0)) != null){
            wallNum += 1;
        }
        if(tilemap.GetTile(pos + new Vector3Int(0,-1,0)) != null){
            wallNum += 2;
        }
        if(tilemap.GetTile(pos + new Vector3Int(-1,0,0)) != null){
            wallNum += 4;
        }
        if(tilemap.GetTile(pos + new Vector3Int(1,0,0)) != null){
            wallNum += 8;
        }
        return wallNum;
    }

    private void updateNeighbors(Vector3Int pos){

        Vector3Int up = pos + new Vector3Int(0,1,0);
        if(tilemap.GetTile(up) != null){
            tilemap.SetTile(up, walls[calculateWallSurroundings(up)]);
        }

        Vector3Int down = pos + new Vector3Int(0,-1,0);
        if(tilemap.GetTile(down) != null){
            tilemap.SetTile(down, walls[calculateWallSurroundings(down)]);
        }

        Vector3Int left = pos + new Vector3Int(-1,0,0);
        if(tilemap.GetTile(left) != null){
            tilemap.SetTile(left, walls[calculateWallSurroundings(left)]);
        }

        Vector3Int right = pos + new Vector3Int(1,0,0);
        if(tilemap.GetTile(right) != null){
            tilemap.SetTile(right, walls[calculateWallSurroundings(right)]);
        }
    }
}
