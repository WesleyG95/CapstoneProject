using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

    //speed of the sword rotation
    public float swordRotation = 13;
    public float lowestSwordLocation = 230;
    public float highestSwordLocation = 330;
    bool isAttacking = false;

    void Update()
    {
        float swordZ = transform.eulerAngles.z;
        bool attack = Input.GetKeyDown(KeyCode.Space);

        if (attack || isAttacking)
        {
            isAttacking = true;
            if(swordZ > lowestSwordLocation)
            {
                transform.Rotate(Vector3.back, swordRotation);
            }
            else
            {
                isAttacking = false;
                transform.eulerAngles = new Vector3(0, 0, highestSwordLocation);
            }
        }
    }
}
