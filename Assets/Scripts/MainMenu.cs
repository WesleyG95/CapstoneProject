using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public bool isStart;
    public bool isQuit;

	void Start () {

	}

    void OnMouseUp()
    {
        if (isStart)
        {
            if (gameObject.tag == "RoomController")
            {
                Destroy(gameObject);
            }
            RoomControl.loadNewScene();
            Cursor.visible = false;
            SceneManager.LoadScene(3);
        }
        if (isQuit)
        {
            Application.Quit();
        }
    } 

    void Update () {
	
	}
}
