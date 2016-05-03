using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimation : MonoBehaviour
{
    public float letterPause = 0.05f;
    public GUIStyle font;
    public GUIStyle skip;
    string story1;
    string story2 = "The sword. It was the only way he could have even a chance against the dark army's commander and, if it was even possible, to free himself from the corruption of darkness that was stealing his soul.  If {Player} couldn't stop him, the army of this altered world would overrun and destroy the barrier, uniting their world with {Player}'s.  It would spill perpetual shadow across {World} and give free range to all its dark inhabitants.  It would be the end of everything.  It already practically destroyed the castle.  All he had to do was beat the Dark Commander to the sword.  If {Player} got to it first, he could stop all this....";
    string text;
    string skipText = "Skip: Space";

    void Start()
    {
        story1 = "{Player} made it.  The portal worked and he survived.  A few echoing cries from the other side carried through behind him- but for only a few moments before they dissipated into the silence of the small room.  It looked like the castle, but it wasn't.  His memory was suddenly foggy but he held tight a specific voice- the advisor's dying words.";
        text = "";
        StartCoroutine(TypeText(story1));
    }

    IEnumerator TypeText(string story)
    {
        foreach (char letter in story.ToCharArray())
        {
            text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 280, 1024), text, font);
        GUI.Label(new Rect(800, 400, 100, 100), skipText, skip);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            text = story1;
        }

        if (text == story1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                text = "";
                StartCoroutine(TypeText(story2));
            }
        }
    }
}