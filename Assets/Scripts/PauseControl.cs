using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    GameObject[] pauseObjects;

    public int firstLevelId = 4;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the ESC button to pause and unpause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        Cursor.visible = true;

        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        Cursor.visible = false;

        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(0);
    }
}
