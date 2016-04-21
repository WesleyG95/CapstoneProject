using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimation : MonoBehaviour
{
    public float letterPause = 0.05f;
    public GUIStyle font;
    string message;
    string text;

    void Start()
    {
        message = "{Player} made it.  The portal worked and he survived.  A few echoing cries from the other side carried through behind him- but for only a few moments before they dissipated into the silence of the small room.  It looked like the castle, but it wasn't.  His memory was suddenly foggy but he held tight a specific voice- the advisor's dying words.";
        text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 280, 1024), text, font);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            text = message;
        }
    }
}