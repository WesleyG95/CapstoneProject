using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextAnimation : MonoBehaviour
{
    public float letterPause = 0.03f;
    public GUIStyle font;
    public GUIStyle skip;
    string story1_1 = "{Player} made it.  The portal worked and he survived.  A few echoing cries from the other side carried through behind him- but for only a few moments before they dissipated into the silence of the small room.  It looked like the castle, but it wasn't.  His memory was suddenly foggy but he held tight a specific voice- the advisor's dying words.";
    string story1_2 = "The sword. It was the only way he could have even a chance against the dark army's commander and, if it was even possible, to free himself from the corruption of darkness that was stealing his soul.  If {Player} couldn't stop him, the army of this altered world would overrun and destroy the barrier, uniting their world with {Player}'s.  It would spill perpetual shadow across {World} and give free range to all its dark inhabitants.  It would be the end of everything.  It already practically destroyed the castle.  All he had to do was beat the Dark Commander to the sword.  If {Player} got to it first, he could stop all this....";


    string storyFinal1 = "The Dark Commander falls!  Upon entering the final door, leaving the commander's broken body behind, {Player} was spit back into his world near to where he first departed.  He stood from his knees, scanning the grand throne room.  The dust of demons departed, shimmering in the sun that was again beaming through the colored windows, was still drifting through the room.  They were gone, and light returned to {World}.  But the ones lost were not to be revived, and their count was sickening.";
    string storyFinal2 = "{Player} stood in a daze for a while, unsure of how to feel, but living voices pushed him forward.  The court mage... she survived!  The fact that she did was enough of a relief.  At least someone did.  She and the rest of the world would breathe another day to remember this hell, while {Player} would relive it nightmares for some time to come.";
    string storyFinal3 = "Victory came with a heavy price....  'Were there ever any winners in war?' {Player} wondered.  How could there be?  It would take years before {World} would ever feel normal again.";

    string text;
    string skipText = "Skip: Space";
    int spacePressedCount = 0;

    void Start()
    {
        StopAllCoroutines();
        //get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        //check what scene is active
        if (currentScene.name == "StoryBlock1")
        {
            text = "";
            StartCoroutine(TypeText(story1_1));
        }
        //more story blocks here

        else if (currentScene.name == "FinalStory")
        {
            text = "";
            StartCoroutine(TypeText(storyFinal1));
        }
    }

    //types the text to the screen
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
        GUI.Label(new Rect(100, 80, 280, 1024), text, font);
        GUI.Label(new Rect(810, 380, 200, 100), skipText, skip);
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "StoryBlock1")
        {
            //space bar is pressed
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //player skipped text typing and sees the entire storyblock1
                if (spacePressedCount == 0)
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = story1_1;
                }

                //start storyblock1 part 2
                else if ((spacePressedCount == 1) && (text == story1_1))
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = "";
                    StartCoroutine(TypeText(story1_2));
                }

                else if (spacePressedCount == 2)
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = story1_2;
                }

                //story is finished and the game begins
                else if ((spacePressedCount == 3) && (text == story1_2))
                {
                    SceneManager.LoadScene("Room1");
                }
                else { Debug.Log("Huge Error- storyblock1"); }
            }
        }
        else if (currentScene.name == "StoryBlock2")
        {
            //stuff to come
        }
        //end game story
        else if (currentScene.name == "FinalStory")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (spacePressedCount == 0)
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = storyFinal1;
                }
                //start final story part 2
                else if ((spacePressedCount == 1) && (text == storyFinal1))
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = "";
                    StartCoroutine(TypeText(storyFinal2));
                }
                else if (spacePressedCount == 2)
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = storyFinal2;
                }
                //start final story part 3
                else if ((spacePressedCount == 3) && (text == storyFinal2))
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = "";
                    StartCoroutine(TypeText(storyFinal3));
                }

                else if (spacePressedCount == 4)
                {
                    spacePressedCount++;
                    StopAllCoroutines();
                    text = storyFinal3;
                }
                else if ((spacePressedCount == 5) && (text == storyFinal2))
                {
                    //load credits
                    Application.Quit();
                }
            }
        }
    }
}