using UnityEngine;
using System.Collections;

public class SpawnMinions : MonoBehaviour {

    public GameObject skull;

	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("spawnMinions", 5f, 5f);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void spawnMinions()
    {
        foreach (Transform child in GameObject.FindGameObjectWithTag("SkullSpawns").transform)
        {
            GameObject newSkull = GameObject.Instantiate(skull);
            newSkull.transform.position = child.transform.position;
        }
    }
}
