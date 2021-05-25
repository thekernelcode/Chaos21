using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public WorldTileMap worldTileMap;
    GameManager gameManager;
    Unit unit;

    // Start is called before the first frame update
    void Start()
    {

        unit = GetComponent<Unit>();
        worldTileMap = FindObjectOfType<WorldTileMap>();
        gameManager = FindObjectOfType<GameManager>();

        unit.unitXPos = (int)transform.position.x;
        unit.unitYPos = (int)transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //TODO Check for if it is player 1s turn etc
        if (unit.endOfTurn != true && gameManager.activeUnit.GetComponent<Unit>() == unit)
        {
            if (Input.GetKeyUp(KeyCode.Keypad8))
            {
                if (worldTileMap.getTile(unit.unitXPos, unit.unitYPos + 1).isWalkable == true)
                {
                    transform.Translate(Vector3.forward);
                    unit.unitXPos = (int)transform.position.x;
                    unit.unitYPos = (int)transform.position.z;
                    gameManager.activeUnit.GetComponent<Unit>().actionPoints--;

                    if (gameManager.activeUnit.GetComponent<Unit>().actionPoints == 0)
                    {
                        unit.endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                if (worldTileMap.getTile(unit.unitXPos, unit.unitYPos - 1).isWalkable == true)
                {
                    transform.Translate(Vector3.back);
                    unit.unitXPos = (int)transform.position.x;
                    unit.unitYPos = (int)transform.position.z;

                    //TODO This could be shortened to unit.actionPoints?
                    gameManager.activeUnit.GetComponent<Unit>().actionPoints--;

                    if (gameManager.activeUnit.GetComponent<Unit>().actionPoints == 0)
                    {
                        unit.endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                if (worldTileMap.getTile(unit.unitXPos - 1 , unit.unitYPos).isWalkable == true)
                {
                    transform.Translate(Vector3.left);
                    unit.unitXPos = (int)transform.position.x;
                    unit.unitYPos = (int)transform.position.z;

                    //TODO This could be shortened to unit.actionPoints?
                    gameManager.activeUnit.GetComponent<Unit>().actionPoints--;

                    if (gameManager.activeUnit.GetComponent<Unit>().actionPoints == 0)
                    {
                        unit.endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                if (worldTileMap.getTile(unit.unitXPos + 1 , unit.unitYPos).isWalkable == true)
                {
                    transform.Translate(Vector3.right);
                    unit.unitXPos = (int)transform.position.x;
                    unit.unitYPos = (int)transform.position.z;

                    //TODO This could be shortened to unit.actionPoints?
                    gameManager.activeUnit.GetComponent<Unit>().actionPoints--;

                    if (gameManager.activeUnit.GetComponent<Unit>().actionPoints == 0)
                    {
                        unit.endOfTurn = true;
                    }
                }
                else
                {
                    Debug.Log("Can't walk here, there's a wall, dummy!");
                }
            }

            gameManager.UpdateUI();
            gameManager.UpdateTiles();
        }

    }

}

