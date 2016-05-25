using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

    //speed of the sword rotation
    public float swordRotation = 13;
    public float totalAttackFrames = 8;
    public int damage = 10;

    float currentAttackFrame = 0;
    string currentDirection = "";

    bool isAttacking = false;
    bool startAttack = false;


    //starting sword rotations for attack
    float swordDownAttackZ = 140f;
    float swordUpAttackZ = 350f;
    float swordLeftAttackZ = 210.81f;
    float swordRightAttackZ = 210.81f;

    //starting sword positions for attack
    float swordUpX = 0.0579f;
    float swordUpY = -0.046f;
    float swordDownX = -0.0579f;
    float swordDownY = -0.046f;
    float swordLeftX = 0.014f;
    float swordLeftY = -0.064f;
    float swordRightX = 0.014f;
    float swordRightY = -0.064f;

    Transform playerT;

    void Start()
    {
        playerT = transform.parent.GetComponent<Transform>();
    }

    void Update()
    {
        startAttack = Input.GetKeyDown(KeyCode.Space);
        currentDirection = transform.parent.GetComponent<PlayerScript>().currentDirection;

        if (startAttack || isAttacking)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            attack(currentDirection);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyAI>().health -= damage;

            float xdif = collision.transform.position.x - transform.position.x;
            float ydif = collision.transform.position.y - transform.position.y;

            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(xdif, ydif).normalized * 400);
        }
        else if (collision.tag == "RemovableFurniture")
        {
            collision.GetComponent<SecretPotion>().health -= damage;
        }
    }

    void attack(string direction)
    {
        int sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
        float swordZ;

        swordZ = transform.eulerAngles.z;
        isAttacking = true;

        if(startAttack)
        {
            if (direction == "down")
            {
                //move sword
                this.transform.position = playerT.transform.position + new Vector3(swordDownX, swordDownY, 0);

                //change sorting order of sword
                sortingOrder = 2;

                //change rotation of sword
                transform.eulerAngles = new Vector3(0, 0, swordDownAttackZ);
            }
            else if (direction == "up")
            {
                //move sword
                this.transform.position = playerT.transform.position + new Vector3(swordUpX, swordUpY, 0);

                //change sorting order of the sword
                sortingOrder = 0;

                //change rotation of sword
                transform.eulerAngles = new Vector3(0, 0, swordUpAttackZ);

            }
            else if (direction == "left")
            {
                //move sword
                this.transform.position = playerT.transform.position + new Vector3(swordLeftX, swordLeftY, 0);

                //change sorting order of the sword
                sortingOrder = 0;

                //change rotation of sword
                transform.eulerAngles = new Vector3(0, 0, swordLeftAttackZ);
            }
            else
            {
                //move sword
                this.transform.position = playerT.transform.position + new Vector3(swordRightX, swordRightY, 0);

                //change sorting order of the sword
                sortingOrder = 2;

                //change rotation of sword
                transform.eulerAngles = new Vector3(0, 0, swordRightAttackZ);
            }
        }
        else
        {
            if (currentAttackFrame < totalAttackFrames)
            {
                transform.Rotate(Vector3.forward, swordRotation);
            }
            else
            {
                currentAttackFrame = 0;
                isAttacking = false;
            }

            currentAttackFrame++;
        }

        startAttack = false;
        GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
    }
}
