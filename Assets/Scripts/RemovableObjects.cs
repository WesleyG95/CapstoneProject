﻿using UnityEngine;
using System.Collections;

public class RemovableObjects : MonoBehaviour {

    public static int count = 0;
    public int objectId;
    public bool alive = true;

    public RemovableObjects()
    {
        objectId = count;
        count++;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Die()
    {

    }
}
