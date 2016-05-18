using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{

    public bool isRestartCheckpoint;
    public bool isQuitToMenu;

    void Start()
    {
        Cursor.visible = true;
    }

    void OnMouseUp()
    {
        if (isRestartCheckpoint)
        {
            Cursor.visible = false;
            //this is not working
            LevelManager.changeToPreviousLvl();
        }
        if (isQuitToMenu)
        {
            SceneManager.LoadScene(RoomControl.mainMenuScene);
        }
    }
}

