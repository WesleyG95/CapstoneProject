using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    void Start()
    {
        Cursor.visible = true;
    }


    /* keeping this for now
    public int numSeconds = 5;
    int currentFrame = 0;
    int totalFrames;

	// Use this for initialization
	void Start () {
        totalFrames = numSeconds * 60;
	}
	
	// Update is called once per frame
	void Update () {
        currentFrame++;
        if (currentFrame > totalFrames)
        {
            Application.Quit();
        }
	}*/
}
