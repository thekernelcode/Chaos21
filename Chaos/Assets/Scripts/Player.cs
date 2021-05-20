using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public WorldTileMap worldTileMap;
    GameManager gameManager;
    SpellBook spellBook;

    public int unitXPos;
    public int unitYPos;
    //public bool endOfTurn;

    //public Slider healthSlider;
    //public Slider actionPointsSlider;

    //public float maxActionPoints = 3f;
    //public float maxHealth = 100f;

    //public float health;
    //public float actionPoints;

    public List<GameObject> castableMonsters = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Player needs to know what world it is in.
        worldTileMap = FindObjectOfType<WorldTileMap>();
        gameManager = FindObjectOfType<GameManager>();
        spellBook = FindObjectOfType<SpellBook>();

        unitXPos = 1;
        unitYPos = 1;

        //health = maxHealth;
        //actionPoints = maxActionPoints;


        //healthSlider.maxValue = maxHealth/maxHealth;
        //actionPointsSlider.maxValue = maxActionPoints/maxActionPoints;

        //healthSlider.value = health / maxHealth;
        //actionPointsSlider.value = actionPoints / maxActionPoints;


    }

    // Update is called once per frame
    void Update()
    {

    }

}
