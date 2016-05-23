using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PotionPickUp : RemovableObjects 
{
    public void pickup()
    {
        Inventory playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerInv.HealthInv++;
        GameObject.FindGameObjectWithTag("UIPotions").GetComponent<Text>().text = "X " + playerInv.HealthInv;
        RoomControl.sceneObjects[this.objectId] = true;
        Die();
    }
}
