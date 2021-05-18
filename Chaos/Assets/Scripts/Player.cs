using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public WorldTileMap worldTileMap;

    int playerXPos;
    int playerYPos;



    // Start is called before the first frame update
    void Start()
    {
        // Player needs to know what world it is in.
        worldTileMap = FindObjectOfType<WorldTileMap>();

        playerXPos = 1;
        playerYPos = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Tile t = getTile(playerXPos, playerYPos);
        t.hasPlayer = true;
    }

    Tile getTile(int x, int y)
    {
        foreach (Tile tile in worldTileMap.tiles)
        {
            if (tile.xPos == playerXPos && tile.yPos == playerYPos)
            {
                return tile;
            }
        }

        return null;
    }
}
