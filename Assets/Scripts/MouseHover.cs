using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseHover : MonoBehaviour {

    Text selection;

    void Start()
    {
        selection = GetComponent<Text>();
        selection.color = Color.gray;
    }

    void OnMouseEnter()
    {
        selection.color = Color.white;
    }

    void OnMouseExit()
    {
        selection.color = Color.gray;
    }
}
