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

    //Original for 3D text: GetComponent<Renderer>().material.color
    // Update is called once per frame
    void Update () {
	
	}
}
