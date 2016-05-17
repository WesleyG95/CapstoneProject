using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int lastLevel = 0;
    private static string direction;

    public static void setLastLevel(int level)
    {
        lastLevel = level;
    }

    public static void changeToPreviousLvl()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(lastLevel);
    }
}
