using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

    //speed of the sword rotation
    public float swordRotation = 13;
    public float longestSwordSwing = 100;
    float startingSwordLocation = 0;
    float endingSwordLocation = 0;
    float currentSwordSwing = 0;

    bool isAttacking = false;

    Animator anim;

    void Start()
    {
        startingSwordLocation = transform.eulerAngles.z;
        endingSwordLocation = startingSwordLocation - longestSwordSwing;
        anim = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.WalkDown"))
        {
            //change location of sword here
        }

        float swordZ = transform.eulerAngles.z;
        bool attack = Input.GetKeyDown(KeyCode.Space);

        if (attack || isAttacking)
        {
            isAttacking = true;
            if (swordZ > endingSwordLocation)
            {
                transform.Rotate(Vector3.back, swordRotation);
                currentSwordSwing += swordRotation;
            }
            else
            {
                isAttacking = false;
                transform.eulerAngles = new Vector3(0, 0, startingSwordLocation);
            }
        }
        else
        {
            startingSwordLocation = transform.eulerAngles.z;
            endingSwordLocation = startingSwordLocation - longestSwordSwing;
        }
    }
}
