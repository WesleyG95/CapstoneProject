using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour {

    public GameObject camera;
    public int speed = 1;
	
    void Start()
    {
        StartCoroutine("WaitForFinish");
    }

	// Update is called once per frame
	void Update () 
    {
        camera.transform.Translate(Vector2.down * Time.deltaTime * speed);
	}
    IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(23);

        Cursor.visible = true;
        SceneManager.LoadScene(RoomControl.mainMenuScene);
    }
}
