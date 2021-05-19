using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTileMap : MonoBehaviour
{

    public TileType[] tileTypes;

    public GameObject enviromentParent;

    public List<Tile> tiles = new List<Tile>();

    int[,] tileArray;

    public int mapSizeX = 10;
    public int mapSizeY = 10;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        GenerateMapVisual();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateMapData()
    {
        tileArray = new int[mapSizeX,mapSizeY];

        // Initialise tile array to be 0s
        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                //TODO Make it so walls are hidden when camera can't see units behind.  For now, just disabled the front wall
                // Define walls tiles
                if (x == 0 || x == mapSizeX - 1 /*|| y == 0 */ || y == mapSizeY - 1)
                {
                    tileArray[x, y] = 0;
                }

                // Fill in all others
                else
                {
                    tileArray[x, y] = 1;
                }
            }
        }
    }

    private void GenerateMapVisual()
    {
        // Allocate tiletype to tile array to be 0s
        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                TileType tt = tileTypes[tileArray[x, y]];

                // Instanstiate Prefab
                GameObject go = (GameObject)Instantiate(tt.tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                go.transform.parent = enviromentParent.transform;
                Tile t = go.GetComponent<Tile>();
                t.xPos = x;
                t.yPos = y;
                tiles.Add(t);
                                    
            }
        }
    }



    public Tile getTile(int x, int y)
    {
        foreach (Tile tile in tiles)
        {
            if (tile.xPos == x && tile.yPos == y)
            {
                return tile;
            }
        }

        return null;
    }

}
