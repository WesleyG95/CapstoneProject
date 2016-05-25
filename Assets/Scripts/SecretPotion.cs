using UnityEngine;
using System.Collections;


public class SecretPotion : RemovableObjects
{
    public Transform target;
    public int moveSpeed = 1;
    public int viewDistance = 3;
    public int health = 10;
    public int damage = 10;
    public bool facingRight = true;

    float playerDistance;
    float moveH;
    float moveV;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (health <= 0)
            {
                Die();
            }
            playerDistance = Mathf.Abs((target.position - transform.position).x) + Mathf.Abs((target.position - transform.position).y);

        }    
    }
}
