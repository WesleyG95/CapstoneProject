using UnityEngine;
using System.Collections;

public class PotionPickUp : RemovableObjects 
{

    public PotionPickUp()
    {
        RemovableObjects.count++;
    }
    public void pickup()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().HealthInv++;
        RoomControl.sceneObjects[this.objectId] = true;
        Die();
    }
}
