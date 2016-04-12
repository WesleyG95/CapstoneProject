using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockedDoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        bool isEnemies = true;
        isEnemies = checkForEnemies();
	}

    bool checkForEnemies()
    {
        GameObject[] a = new GameObject[]();
        a = GameObject.FindGameObjectsWithTag("Enemy");
        return true;
    }
}
