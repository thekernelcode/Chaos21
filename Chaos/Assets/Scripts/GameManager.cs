using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    WorldTileMap worldTileMap;
    Player player;

    int turnNumber;

    // Start is called before the first frame update
    void Start()
    {
        worldTileMap = FindObjectOfType<WorldTileMap>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndPlayerTurn()
    {
        turnNumber++;
        player.actionPoints = player.maxActionPoints;
        UpdateUI();



        player.endOfTurn = false;
    }

    public void UpdateUI()
    {
        player.actionPointsSlider.value = player.actionPoints / player.maxActionPoints;
    }

    public void UpdateTiles()
    {
            for (int y = 0; y < worldTileMap.mapSizeY; y++)
            {
                for (int x = 0; x < worldTileMap.mapSizeX; x++)
                {
                    Tile t = worldTileMap.getTile(x, y);
                    if (t.xPos == player.playerXPos && t.yPos == player.playerYPos)
                    {
                        t.hasPlayer = true;
                    }
                    else
                    {
                        t.hasPlayer = false;
                    }
                }
            }

    }


}
