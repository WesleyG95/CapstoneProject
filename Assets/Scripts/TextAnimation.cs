using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextAnimation : MonoBehaviour
{
    public float letterPause = 0.02f;
    public GUIStyle font;
    public GUIStyle skip;
    string story1_1 = "Sunil made it.  The portal worked and he survived.  A few echoing cries from the other side carried through behind him- but for only a few moments before they dissipated into the silence of the small room.  It looked like the castle, but it wasn't.  \n\nHis memory was suddenly foggy; he held tight a specific voice- the advisor's dying words. \n\nThe sword. It was the only way he could have even a chance against the dark army's commander Erebus and, if it was even possible, to free himself from the corruption of darkness that was stealing his soul. \n\nIf Sunil couldn't stop him, the army of this altered world would overrun and destroy the barrier, uniting their world with Sunil's.  It would spill perpetual shadow across Ardengard and give free range to all its dark inhabitants.  It would be the end of everything.";
    string story1_2 = "It already practically destroyed the castle.  The king, his wife and daughter, nearly all of his court and guard- gone.  The court mage, Runa, was the only one Sunil could find among the dead.\n\nWith a powerful force of unknown origin, Commander Erebus managed to open a gate to the world of light and allowed tens of his minions to unexpectedly enter the castle.  By the same force weilded by the castle's court mage, Sunil was allowed to enter this world the same way.  \n\nHe left his world of light and entered the darness- even as soldiers died behind him.  All he had to do was beat the Dark Commander to the sword.  If Sunil got to it first, he could stop all this....";

    string storyFinal1 = "The Dark Commander Erebus falls!  Upon entering the final door, leaving the commander's broken body behind, Sunil was spit back into his world near to where he first departed.  He stood from his knees, scanning the grand throne room.  The dust of demons departed, shimmering in the sun that was again beaming through the colored windows, still drifted through the room.  They were gone, and light returned to Ardengard.  But the ones lost were not to be revived, and their count was sickening.";
    string storyFinal2 = "Sunil stood in a daze for a while, unsure of how to feel, but living voices pushed him forward.  Runa, the court mage... she survived!  The fact that she did was enough of a relief, as so many others perished.  At least someone still walked here.  She and the rest of Ardengard would breathe another day to remember this hell, while Sunil would relive it in nightmares for some time to come.  Victory came with a heavy price... as it always did and will in war.";

    string text;
    string skipText = "Skip and Continue: SPACE";
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

        else if (currentScene.name == "FinalStory")
        {
            text = "";
            StartCoroutine(TypeText(storyFinal1));
        }
    }

    //types the text to the screen
    IEnumerator TypeText(string story)
    {
        Debug.Log("type text started");
        foreach (char letter in story.ToCharArray())
        {
            text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        spacePressed();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 80, 2000, 3000), text, font);
        GUI.Label(new Rect(1000, 600, 200, 100), skipText, skip);
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
                    spacePressed();
                    text = story1_1;
                }

                //start storyblock1 part 2
                else if ((spacePressedCount == 1) && (text == story1_1))
                {
                    spacePressed();
                    text = "";
                    StartCoroutine(TypeText(story1_2));
                }

                else if (spacePressedCount == 2)
                {
                    spacePressed();
                    text = story1_2;
                }

                //story is finished and the game begins
                else if ((spacePressedCount == 3) && (text == story1_2))
                {
                    RoomControl.loadNewScene();
                }
                else { Debug.Log("Error- storyblock1"); }
            }
        }
        //end game story
        else if (currentScene.name == "FinalStory")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (spacePressedCount == 0)
                {
                    spacePressed();
                    text = storyFinal1;
                }
                //start final story part 2
                else if ((spacePressedCount == 1) && (text == storyFinal1))
                {
                    spacePressed();
                    text = "";
                    StartCoroutine(TypeText(storyFinal2));
                }
                else if (spacePressedCount == 2)
                {
                    spacePressed();
                    text = storyFinal2;
                }
                else if ((spacePressedCount == 3) && (text == storyFinal2))
                {
                    SceneManager.LoadScene(RoomControl.creditsScene);
                }
                else { Debug.Log("Error- final storyblock"); }
            }
        }
    }

    void spacePressed()
    {
        spacePressedCount++;
        StopAllCoroutines();
    }
}