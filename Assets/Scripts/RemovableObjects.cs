using UnityEngine;
using System.Collections;

public class RemovableObjects : MonoBehaviour {

    public static int count = 0;
    public int objectId;

    public void Die()
    {
        RoomControl.sceneObjects[this.objectId] = true;
        Destroy(gameObject);
    }
}
