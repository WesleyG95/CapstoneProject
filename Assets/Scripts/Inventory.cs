using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public int HealthInv = 0;
    public int PowerInv = 0;
    public GUIStyle style;
    public GUIStyle style2;
    public bool showGUI = false;

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
    }

    void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.Box(new Rect(20, 40, 50, 50), "Inventory", style);
            GUI.Label(new Rect(20, 90, 60, 60), "Health Potions:", style2);
            GUI.Label(new Rect(250, 90, 40, 30), " " + HealthInv, style2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthPotion")
        {
            HealthInv++;
            Destroy(other.gameObject);
        }
    }
}

