using UnityEngine;
using System.Collections;

public class MouseHover : MonoBehaviour {
    

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
