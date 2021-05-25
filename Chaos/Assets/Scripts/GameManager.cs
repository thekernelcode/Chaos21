using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    WorldTileMap worldTileMap;
    Player player;

    public GameObject activeUnit;

    public int turnNumber;

    public bool isPlayerTurn;

    // Start is called before the first frame update
    void Start()
    {
        worldTileMap = FindObjectOfType<WorldTileMap>();
        player = FindObjectOfType<Player>();
        isPlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                activeUnit = hit.transform.gameObject;
            }
        }
    }

    public void EndTurn()
    {
        turnNumber++;
        activeUnit.GetComponent<Unit>().actionPoints = activeUnit.GetComponent<Unit>().maxActionPoints;
        UpdateUI();

        activeUnit.GetComponent<Unit>().endOfTurn = false;
    }

    public void UpdateUI()
    {
        // TODO Add health and other stats
       activeUnit.GetComponent<Unit>().actionPointsSlider.value = activeUnit.GetComponent<Unit>().actionPoints / activeUnit.GetComponent<Unit>().maxActionPoints;
    }

    public void UpdateTiles()
    {
            for (int y = 0; y < worldTileMap.mapSizeY; y++)
            {
                for (int x = 0; x < worldTileMap.mapSizeX; x++)
                {
                    //TODO Update for all units whether they are active or not/  Would need to loop through all units in game, so potentially a list in the gamemanager needed to track this?
                    Tile t = worldTileMap.getTile(x, y);
                    if (t.xPos == activeUnit.GetComponent<Unit>().unitXPos && t.yPos == activeUnit.GetComponent<Unit>().unitYPos)
                    {
                        t.hasUnit = true;
                    }
                    else
                    {
                        t.hasUnit = false;
                    }
                }
            }

    }


}
