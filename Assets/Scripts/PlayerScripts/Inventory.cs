using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public int HealthInv = 0;
    public int PowerInv = 0;
    public int HealthPotionHeal = 25;
    public GUIStyle style;
    public GUIStyle style2;
    public bool showGUI = false;
    PlayerScript playerScript;

    void Start()
    {
        playerScript = GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (showGUI == false)
            {
                showGUI = true;
            }
            else {
                showGUI = false;
            }
        }

        if ((showGUI == true) && (Input.GetKeyDown(KeyCode.F)) && (HealthInv > 0) && (playerScript.health < playerScript.maxHealth))
        {
            usePotion();
        }
    }

    void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.Box(new Rect(20, 40, 50, 50), "Inventory", style);
            GUI.Label(new Rect(20, 90, 60, 60), "Health Potions(F):", style2);
            GUI.Label(new Rect(280, 90, 40, 30), " " + HealthInv, style2);
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

