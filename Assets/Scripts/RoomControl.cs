using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class RoomControl : MonoBehaviour {

    public static Dictionary<int, bool> sceneObjects = new Dictionary<int, bool>();
    static List<Dictionary<int, bool>> savedScenes = new List<Dictionary<int, bool>>();
    static int id = 0;
    static int sceneNumber = 0;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(transform.gameObject);
        findObjects();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        Debug.Log(sceneNumber);
    }

    void OnLevelWasLoaded()
    {
        removeObjects();
    }

    public static void findObjects()
    {
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            sceneObjects.Add(o.objectId, false);
        }
    }

    public static void endScene()
    {
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            sceneObjects.Add(id, false);
            id++;
        }
    }

    static void reset(int newSceneIndex)
    {
        id = 0;

        if (savedScenes.Count > newSceneIndex)
        {
            //savedScenes[sceneNumber] = sceneObjects;
            sceneObjects = savedScenes[newSceneIndex];
        }
        else
        {
            Debug.Log("scene " + newSceneIndex + " not found, creating new");
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");

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
                Destroy(player);
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
