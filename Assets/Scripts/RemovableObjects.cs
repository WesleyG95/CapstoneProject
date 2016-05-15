using UnityEngine;
using System.Collections;

public class RemovableObjects : MonoBehaviour {

    public static int count = 0;
    public int objectId;
    

    void OnLevelWasLoaded()
    {
        //count = 0;
    }

    // Use this for initialization
    void Start ()
    {
        /*
        objectId = count;

        if (!RoomControl.sceneObjects.ContainsKey(objectId))
        {
            RoomControl.sceneObjects.Add(objectId, false);
        }

        count++;
        */
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Die()
    {
        //Debug.Log(objectId + " Died");
        RoomControl.sceneObjects[this.objectId] = true;
        Destroy(gameObject);
    }
}
