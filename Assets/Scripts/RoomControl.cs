using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class RoomControl : MonoBehaviour {

    public static Dictionary<int, bool> sceneObjects = new Dictionary<int, bool>();
    static List<Dictionary<int, bool>> savedScenes = new List<Dictionary<int, bool>>();
    static int sceneNumber = 0;

	// Use this for initialization
	void Start ()
    {
        findObjects();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded()
    {
        removeObjects();
    }

    public static void findObjects()
    {
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            Debug.Log("added: " + o.objectId);
            sceneObjects.Add(o.objectId, false);
        }
    }

    static void reset(int sceneIndex)
    {
        bool previousSceneExists = false;

        for (int i = 0; i < savedScenes.Count; i++)
        {
            if (i == sceneIndex)
            {
                previousSceneExists = true;
            }
            else if (i == SceneManager.GetActiveScene().buildIndex)
            {
                savedScenes[SceneManager.GetActiveScene().buildIndex] = sceneObjects;
            }
        }

        if (previousSceneExists)
        {
            sceneObjects = savedScenes[sceneIndex];
        }
        else
        {
            Debug.Log("scene " + sceneIndex + " not found, creating new");
            savedScenes.Add(sceneObjects);
            sceneObjects = new Dictionary<int, bool>();
            findObjects();
        }

        /*
        //if scene is not in dictionary, create new dictionary and find objects
        try
        {
            sceneObjects = savedScenes[newSceneIndex];
        }
        catch (Exception e)
        {
            savedScenes.Add(sceneObjects);
            sceneObjects = new Dictionary<int, bool>();
            findObjects();
        }
        */
    }

    static void removeObjects()
    {
        try
        {
            foreach (KeyValuePair<int, bool> i in savedScenes[sceneNumber])
            {
                if (i.Value)
                {
                    foreach (RemovableObjects j in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
                    {
                        if (i.Key == j.objectId)
                        {
                            j.Die();
                        }
                    }
                }
            }
        }
        catch
        {

        }
    }

    public static void loadNewScene(string direction = "forward")
    {
        if (direction == "forward")
        {
            sceneNumber++;
            reset(sceneNumber);

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
            sceneNumber--;
            reset(sceneNumber);
            //load scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
