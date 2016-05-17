using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour {

    public GameObject camera;
    public int speed = 1;
	
	// Update is called once per frame
	void Update () {
        camera.transform.Translate(Vector2.down * Time.deltaTime * speed);

        //get some time to display it all and when it's done
        //load the main menu
	}
}
