using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public bool isStart;
    public bool isQuit;

    void OnMouseUp()
    {
        if (isStart)
        {
            RoomControl.loadNewScene();
            Cursor.visible = false;
            SceneManager.LoadScene(RoomControl.firstLevelScene);
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
}
