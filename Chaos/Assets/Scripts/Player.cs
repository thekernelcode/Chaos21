using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public WorldTileMap worldTileMap;
    GameManager gameManager;
    SpellBook spellBook;

    public int playerXPos;
    public int playerYPos;
    public bool endOfTurn;

    public Slider healthSlider;
    public Slider actionPointsSlider;

    public float maxActionPoints = 3f;
    public float maxHealth = 100f;

    public float health;
    public float actionPoints;

    public List<GameObject> castableMonsters = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Player needs to know what world it is in.
        worldTileMap = FindObjectOfType<WorldTileMap>();
        gameManager = FindObjectOfType<GameManager>();
        spellBook = FindObjectOfType<SpellBook>();

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
                if (worldTileMap.getTile(playerXPos, playerYPos + 1).isWalkable == true)
                {
                    transform.Translate(Vector3.forward);
                    playerXPos = (int)transform.position.x;
                    playerYPos = (int)transform.position.z;
                    actionPoints--;

                    if (actionPoints == 0)
                    {
                        endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                if (worldTileMap.getTile(playerXPos, playerYPos - 1).isWalkable == true)
                {
                    transform.Translate(Vector3.back);
                    playerXPos = (int)transform.position.x;
                    playerYPos = (int)transform.position.z;
                    actionPoints--;

                    if (actionPoints == 0)
                    {
                        endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                if (worldTileMap.getTile(playerXPos - 1, playerYPos).isWalkable == true)
                {
                    transform.Translate(Vector3.left);
                    playerXPos = (int)transform.position.x;
                    playerYPos = (int)transform.position.z;
                    actionPoints--;

                    if (actionPoints == 0)
                    {
                        endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                if (worldTileMap.getTile(playerXPos + 1, playerYPos).isWalkable == true)
                {
                    transform.Translate(Vector3.right);
                    playerXPos = (int)transform.position.x;
                    playerYPos = (int)transform.position.z;
                    actionPoints--;

                    if (actionPoints == 0)
                    {
                        endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }

        }


        gameManager.UpdateUI();
        gameManager.UpdateTiles();

    }

    

}
