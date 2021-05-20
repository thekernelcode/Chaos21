using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitName;

    public bool isPlayer;

    public float maxActionPoints = 5f;
    public float maxHealth = 50f;

    public float health;
    public float actionPoints;

    public Slider healthSlider;
    public Slider actionPointsSlider;

    public int unitXPos;
    public int unitYPos;

    public bool endOfTurn;

    // Start is called before the first frame update
    void Start()
    {
        unitXPos = (int)transform.position.x;
        unitYPos = (int)transform.position.z;

        healthSlider = GameObject.FindGameObjectWithTag("healthSlider").GetComponent<Slider>();
        actionPointsSlider = GameObject.FindGameObjectWithTag("actionPointsSlider").GetComponent<Slider>();

        health = maxHealth;
        actionPoints = maxActionPoints;

        healthSlider.maxValue = maxHealth / maxHealth;
        actionPointsSlider.maxValue = maxActionPoints / maxActionPoints;

        healthSlider.value = health / maxHealth;
        actionPointsSlider.value = actionPoints / maxActionPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
