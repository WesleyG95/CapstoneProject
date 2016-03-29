using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

    int attackFrame = 0;

    //represents how far you are rotating the sword
    int swordRotation = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        Transform sword = GetComponent<Transform>();

        //sword.rotation.z = new Vector3(0, 0, 0);
        /*
        bool attack = Input.GetKeyDown(KeyCode.Space);

        if (attack)
        {
            attackFrame++;
        }

        if (attackFrame >= 1 && attackFrame <= 5)
        {
            sword.rotation = new Quaternion(0, 0, swordRotation, 0);
            attackFrame++;
        }

        if (attackFrame > 5)
        {
            attackFrame = 0;
            sword.rotation = new Quaternion(0, 0, 20, 0);
        }
         */
    }
}
