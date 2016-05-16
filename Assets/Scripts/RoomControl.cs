using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class RoomControl : MonoBehaviour {

    public static Dictionary<int, bool> sceneObjects = new Dictionary<int, bool>();
    static List<Dictionary<int, bool>> savedScenes = new List<Dictionary<int, bool>>();
    static int sceneNumber = 0;
    static bool existsInList = true;

    private static RoomControl _instance;

	// Use this for initialization
	void Start ()
    {
        findObjects();
    }

    void Awake()
    {
        //check if there is another player in the scene
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            //destroy the other player in the scene
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    void OnLevelWasLoaded()
    {
        findObjects();

        if (existsInList)
        {
            removeObjects();

        }
    }

    public static void findObjects()
    {
        int count = 0;

        //assign all removable objects their ids
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            o.objectId = count;
            count++;
            Debug.Log("Id assigned: " + o.objectId);

            if (!existsInList)
            {
                sceneObjects.Add(o.objectId, false);
            }
        }
    }

    static void reset(int newSceneIndex, int currentSceneIndex)
    {
        int newSceneId = -1;
        int currentSceneId = -1;

        for (int i = 0; i < savedScenes.Count; i++)
        {
            if (i == newSceneIndex)
            {
                newSceneId = i;
            }
            else if (i == currentSceneIndex)
            {
                currentSceneId = i;
            }
        }

        if (currentSceneId != -1)
        {
            savedScenes[currentSceneId] = sceneObjects;
        }
        else
        {
            savedScenes.Add(sceneObjects);
        }

        if (newSceneId != -1)
        {
            sceneObjects = savedScenes[newSceneId];

            existsInList = true;
        }
        else
        {
            savedScenes.Add(sceneObjects);
            sceneObjects = new Dictionary<int, bool>();
            existsInList = false;
        }
    }

    static void removeObjects()
    {
        foreach (KeyValuePair<int, bool> i in sceneObjects)
        {
            if (i.Value)
            {
                foreach (RemovableObjects j in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
                {
                    if (i.Key == j.objectId)
                    {
                        Destroy(j.gameObject);
                    }
                }
            }
        }
    }

    public static void loadNewScene(string direction = "forward")
    {
        int newSceneNumber = sceneNumber;

        if (direction == "forward")
        {
            newSceneNumber++;
            reset(newSceneNumber, sceneNumber);
            sceneNumber++;

            if ((SceneManager.sceneCountInBuildSettings - 1) > SceneManager.GetActiveScene().buildIndex)
            {
                //load scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            newSceneNumber--;
            reset(newSceneNumber, sceneNumber);
            sceneNumber--;
            //load scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
