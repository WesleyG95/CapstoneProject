using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockedDoorScript : MonoBehaviour {

    public Sprite openSprite;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        bool isEnemies = true;
        isEnemies = checkForEnemies();

        if (!isEnemies)
        {
            GameObject.FindGameObjectWithTag("LockedDoor").GetComponent<SpriteRenderer>().sprite = openSprite;
            GameObject.FindGameObjectWithTag("LockedDoor").GetComponent<BoxCollider2D>().isTrigger = true;
        }
	}

    bool checkForEnemies()
    {
        GameObject[] a;
        a = GameObject.FindGameObjectsWithTag("Enemy");
        if (a.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
