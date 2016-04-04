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

    Transform t;
    Animator anim;

    void Start()
    {
        startingSwordLocation = transform.eulerAngles.z;
        endingSwordLocation = startingSwordLocation - longestSwordSwing;
        anim = transform.parent.GetComponent<Animator>();
        t = transform.parent.GetComponent<Transform>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        float swordZ = transform.eulerAngles.z;
        bool attack = Input.GetKeyDown(KeyCode.Space);

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.WalkDown"))
        {
            //change location of sword here
            //this.transform.Translate(0.005f, 0, 0);
            //this.transform.position = new Vector3(-0.05f, -0.05f, 1);
            this.transform.position = t.transform.position + new Vector3(-0.05f, -0.05f, 0);
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
            Debug.Log("Down");
        }
        else if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.WalkUp"))
        {
            Debug.Log("Up");
        }
        else if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.WalkH"))
        {
            this.transform.position = t.transform.position + new Vector3(0.015f, -0.06f, 0);
            swordZ = 310.810f;
            transform.eulerAngles = new Vector3(0, 0, 310.81f);
            Debug.Log("H");
        }

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
