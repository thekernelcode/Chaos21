using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public WorldTileMap worldTileMap;

    public int xPos;
    public int yPos;

    // Start is called before the first frame update
    void Start()
    {

        // Tile needs to know what world it is in.
        worldTileMap = FindObjectOfType<WorldTileMap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
