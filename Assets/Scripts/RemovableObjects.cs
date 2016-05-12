using UnityEngine;
using System.Collections;

public class RemovableObjects : MonoBehaviour {

    public static int count = 0;
    public int objectId;
    public bool die = false;

    public RemovableObjects()
    {
        objectId = count;
        if(!RoomControl.sceneObjects.ContainsKey(objectId))
        {
            RoomControl.sceneObjects.Add(objectId, false);
        }

        count++;
        //Debug.Log(objectId);
    }

    void OnLevelWasLoaded()
    {
        count = 0;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Die()
    {
        Debug.Log(objectId + " Died");
        RoomControl.sceneObjects[this.objectId] = true;
        Destroy(gameObject);
    }
}
