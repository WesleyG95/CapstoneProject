using UnityEngine;
using System.Collections;

public class SyncSpawnExit : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<PlayerScript>().direction == "back")
        {
            player.GetComponent<Transform>().position = transform.position;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
