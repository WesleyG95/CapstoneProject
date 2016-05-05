using UnityEngine;
using System.Collections;

public class PotionPickUp : RemovableObjects 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.GetComponent<Inventory>().HealthInv++;
            //Destroy(gameObject);
        }
    }
}
