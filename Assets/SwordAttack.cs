using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

    //speed of the sword rotation
    public float swordRotation = 13;
    public float longestSwordSwing = 100;
    float startingSwordLocation = 0;
    float endingSwordLocation = 0;
    string currentDirection = "";

    bool isAttacking = false;

    float swordDownX = -0.0579f;
    float swordDownY = -0.046f;

    float swordDownAttackZ = 140f;

    float swordUpX = 0.0579f;
    float swordUpY = -0.046f;

    float swordHX = 0.014f;
    float swordHY = -0.064f;
    
    Animator anim;
    Transform playerT;

    void Start()
    {
        startingSwordLocation = transform.eulerAngles.z;
        endingSwordLocation = startingSwordLocation - longestSwordSwing;
        anim = transform.parent.GetComponent<Animator>();
        playerT = transform.parent.GetComponent<Transform>();
    }

    void Update()
    {
        float swordZ;
        bool attack = Input.GetKeyDown(KeyCode.Space);

        currentDirection = transform.parent.GetComponent<PlayerScript>().currentDirection;
        adjustSword(currentDirection);

        swordZ = transform.eulerAngles.z;

        if (currentDirection == "down" && attack)
        {
            transform.eulerAngles = new Vector3(0, 0, swordDownAttackZ);
            startingSwordLocation = transform.eulerAngles.z;
            endingSwordLocation = startingSwordLocation + longestSwordSwing;
        }

        if (attack || isAttacking)
        {
            isAttacking = true;

            if (currentDirection == "down" || currentDirection == "up")
            {
                if (swordZ < endingSwordLocation)
                {
                    transform.Rotate(Vector3.forward, swordRotation);
                }
                else
                {
                    isAttacking = false;
                    transform.eulerAngles = new Vector3(0, 0, startingSwordLocation);
                }
            }
            else
            {
                if (swordZ > endingSwordLocation)
                {
                    transform.Rotate(Vector3.back, swordRotation);
                }
                else
                {
                    isAttacking = false;
                    transform.eulerAngles = new Vector3(0, 0, startingSwordLocation);
                }
            }
        }
    }

    void adjustSword(string direction)
    {
        int sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;

        if (direction == "down")
        {
            //moves sword
            this.transform.position = playerT.transform.position + new Vector3(swordDownX, swordDownY, 0);

            //changes sorting order of the sword
            sortingOrder = 2;

            //changes rotation of sword
            if (isAttacking)
            {
                //transform.eulerAngles = new Vector3(0, 0, swordDownAttackZ);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (direction == "up")
        {
            //moves sword
            this.transform.position = playerT.transform.position + new Vector3(swordUpX, swordUpY, 0);

            //changes sorting order of the sword
            sortingOrder = 0;

            //changes rotation of sword
            if (!isAttacking)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                startingSwordLocation = transform.eulerAngles.z;
                endingSwordLocation = longestSwordSwing;
            }
        }
        else
        {
            //moves sword
            this.transform.position = playerT.transform.position + new Vector3(swordHX, swordHY, 0);

            //changes sorting order of the sword
            sortingOrder = 0;

            //changes rotation of sword
            if (!isAttacking)
            {
                transform.eulerAngles = new Vector3(0, 0, 310.81f);
                startingSwordLocation = transform.eulerAngles.z;
                endingSwordLocation = startingSwordLocation - longestSwordSwing;
            }
        }

        GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
    }
}
