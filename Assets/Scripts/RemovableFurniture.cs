using UnityEngine;
using System.Collections;


public class RemovableFurniture : RemovableObjects
{
    public Transform target;
    public int moveSpeed = 1;
    public int viewDistance = 3;
    public int health = 10;
    public int damage = 10;
    public bool facingRight = true;

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

        }    
    }
}
