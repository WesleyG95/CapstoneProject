using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockedDoorScript : MonoBehaviour {

    public Sprite openSprite;
    GameObject[] enemies;

	void Start () 
    {
        //find all the enemies in the scene
	    enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //delete every enemy clone in the scene (for animator bug that creates clones that we can't delete)
        foreach (GameObject clone in enemies)
        {
            if (clone.name == "Enemy(Clone)")
            {
                GameObject.Destroy(clone);
            }
        }
	}
	
	void Update () 
    {
        bool isEnemies;
        isEnemies = checkForEnemies();

        if (!isEnemies)
        {
            //open door
            GetComponent<SpriteRenderer>().sprite = openSprite;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
	}

    bool checkForEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
