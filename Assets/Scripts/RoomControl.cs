using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class RoomControl : MonoBehaviour {

    static Dictionary<int, bool> sceneObjects = new Dictionary<int, bool>();
    static List<Dictionary<int, bool>> savedScenes = new List<Dictionary<int, bool>>();
    static List<RemovableObjects> removableObjectsInScene = new List<RemovableObjects>();
    static int id = 0;

	// Use this for initialization
	void Start ()
    {
        startScene();
        DontDestroyOnLoad(transform.gameObject);
	}

    void OnLevelWasLoaded()
    {
        reset();
        startScene();
        removeObjects();
    }
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
    public static void startScene()
    {
        foreach (RemovableObjects o in GameObject.FindObjectsOfType(typeof(RemovableObjects)))
        {
            sceneObjects.Add(id, true);
            removableObjectsInScene.Add(o);
            o.objectId = id;
            id++;
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

    void reset()
    {
        savedScenes.Add(sceneObjects);
        id = 0;
        foreach (KeyValuePair<int, bool> o in sceneObjects)
        {
            Debug.Log(o.Key);
            Debug.Log(o.Value);
        }
        sceneObjects = new Dictionary<int, bool>();
    }

    void removeObjects()
    {
        try
        {
            foreach (KeyValuePair<int, bool> o in savedScenes[SceneManager.GetActiveScene().buildIndex])
            {
                if (o.Value)
                {
                    //removableObjectsInScene[o.Key].Die();
                }
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }
}
