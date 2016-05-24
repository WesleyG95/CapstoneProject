using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int HealthInv = 0;
    public int PowerInv = 0;
    public int HealthPotionHeal = 25;
    PlayerScript playerScript;

    void Start()
    {
        playerScript = GetComponent<PlayerScript>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F)) && (HealthInv > 0) && (playerScript.health < playerScript.maxHealth))
        {
            usePotion();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthPotion")
        {
            other.GetComponent<PotionPickUp>().pickup();
        }
    }

    void usePotion()
    {
        if (playerScript.health > playerScript.maxHealth - HealthPotionHeal)
        {
            playerScript.health = 100;
        }
        else
        {
            playerScript.health += HealthPotionHeal;
        }

        HealthInv--;
    }
}

