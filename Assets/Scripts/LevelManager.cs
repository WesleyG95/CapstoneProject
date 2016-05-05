using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private static string lastLevel;

    public static void setLastLevel(string level)
    {
        lastLevel = level;
    }

    public static string getLastLevel()
    {
        return lastLevel;
    }

    public static void changeToPreviousLvl()
    {
        SceneManager.LoadScene(lastLevel);
    }
}
