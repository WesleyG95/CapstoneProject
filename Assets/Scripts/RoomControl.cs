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

    void Update()
    {
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            if (o.isActiveAndEnabled)
            {
                Debug.Log("object id added: " + o.objectId);
            }
            //sceneObjects.Add(o.objectId, false);
        }
    }

    void OnLevelWasLoaded()
    {
        removeObjects();
    }

    public static void findObjects()
    {
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            //Debug.Log("object id added: " + o.objectId);
            //sceneObjects.Add(o.objectId, false);
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
        }
        else
        {
            savedScenes.Add(sceneObjects);
            sceneObjects = new Dictionary<int, bool>();
            findObjects();
        }
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
            reset(sceneNumber++, sceneNumber);
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
            reset(sceneNumber--, sceneNumber);
            sceneNumber--;
            //load scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
