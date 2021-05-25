using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public WorldTileMap worldTileMap;
    GameManager gameManager;
    SpellBook spellBook;

    public int unitXPos;
    public int unitYPos;

    public List<GameObject> castableMonsters = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Player needs to know what world it is in.
        worldTileMap = FindObjectOfType<WorldTileMap>();
        gameManager = FindObjectOfType<GameManager>();
        spellBook = FindObjectOfType<SpellBook>();

        unitXPos = 8;
        unitYPos = 8;

    }

    // Update is called once per frame
    void Update()
    {

    }

}
