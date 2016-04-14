using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

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
	}
}
