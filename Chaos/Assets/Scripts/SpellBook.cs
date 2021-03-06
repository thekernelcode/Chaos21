using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    public Player player;

    public Sprite spellImage;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        GetSpellImage();

       this.GetComponent<Image>().sprite = spellImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetSpellImage()
    {
        spellImage = player.castableMonsters[transform.GetSiblingIndex()].GetComponent<Image>().sprite;
    }

    public void spawnMonster()
    {
        GameObject monster = player.castableMonsters[transform.GetSiblingIndex()];
        Instantiate(monster, new Vector3(player.unitXPos + 1, 1, player.unitYPos + 1), Quaternion.identity);
        player.castMonsters.Add(monster);
    }
}
