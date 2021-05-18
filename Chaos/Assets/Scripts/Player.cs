using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public WorldTileMap worldTileMap;

    [SerializeField]
    int playerXPos;
    [SerializeField]
    int playerYPos;
    [SerializeField]
    bool endOfTurn;

    public Slider healthSlider;
    public Slider actionPointsSlider;

    float maxActionPoints = 3f;
    float maxHealth = 100f;

    float health;
    float actionPoints;

    //public Button resetTurn;

    // Start is called before the first frame update
    void Start()
    {
        // Player needs to know what world it is in.
        worldTileMap = FindObjectOfType<WorldTileMap>();

        playerXPos = 1;
        playerYPos = 1;

        health = maxHealth;
        actionPoints = maxActionPoints;


        healthSlider.maxValue = maxHealth/maxHealth;
        actionPointsSlider.maxValue = maxActionPoints/maxActionPoints;

        healthSlider.value = health / maxHealth;
        actionPointsSlider.value = actionPoints / maxActionPoints;


    }

    // Update is called once per frame
    void Update()
    {
        if (endOfTurn != true)
        {
            if (Input.GetKeyUp(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.forward);
                playerXPos = (int)transform.position.x;
                playerYPos = (int)transform.position.z;
                actionPoints--;

                UpdateUI();

                if (actionPoints == 0)
                {
                    endOfTurn = true;
                }

                UpdateTiles();
            }
            if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                transform.Translate(Vector3.back);
                playerXPos = (int)transform.position.x;
                playerYPos = (int)transform.position.z;
                actionPoints--;

                UpdateUI();

                if (actionPoints == 0)
                {
                    endOfTurn = true;
                }
                UpdateTiles();
            }
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left);
                playerXPos = (int)transform.position.x;
                playerYPos = (int)transform.position.z;
                actionPoints--;

                UpdateUI();

                if (actionPoints == 0)
                {
                    endOfTurn = true;
                }

                UpdateTiles();
            }
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right);
                playerXPos = (int)transform.position.x;
                playerYPos = (int)transform.position.z;
                actionPoints--;

                UpdateUI();

                if (actionPoints == 0)
                {
                    endOfTurn = true;
                }

                UpdateTiles();
            }

        }
        

    }

    Tile getTile(int x, int y)
    {
        foreach (Tile tile in worldTileMap.tiles)
        {
            if (tile.xPos == x && tile.yPos == y)
            {
                return tile;
            }
        }

        return null;
    }

    void UpdateTiles()
    {
        if (endOfTurn)
        {
            for (int y = 0; y < worldTileMap.mapSizeY; y++)
            {
                for (int x = 0; x < worldTileMap.mapSizeX; x++)
                {
                    Tile t = getTile(x, y);
                    if (t.xPos == playerXPos && t.yPos == playerYPos)
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

    public void ResetTurn()
    {
        actionPoints = maxActionPoints;
        UpdateUI();
        endOfTurn = false;
    }

    void UpdateUI()
    {
        actionPointsSlider.value = actionPoints / maxActionPoints;
    }
}
