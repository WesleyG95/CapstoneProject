using UnityEngine;
using System.Collections;

public class EnemyAI : RemovableObjects
{
    public Transform target;
    public int moveSpeed = 1;
    public int viewDistance = 3;
    public int health = 100;
    public int damage = 10;
    public bool facingRight = true;

    float playerDistance;
    float moveH;
    float moveV;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        moveH = (target.position - transform.position).normalized.x;
        moveV = (target.position - transform.position).normalized.y;

        //set SpeedH to the absolute value of moveH
        anim.SetFloat("EnemySpeedH", Mathf.Abs(moveH));

        //set SpeedV to the value of moveV
        anim.SetFloat("EnemySpeedV", moveV);
        
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            playerDistance = Mathf.Abs((target.position - transform.position).x) + Mathf.Abs((target.position - transform.position).y);

            if ((target != null) && (playerDistance <= viewDistance))
            {
                //Move Towards Target
                transform.position += (target.position - transform.position).normalized * moveSpeed * 0.005f;

                if (moveH > 0 && !facingRight)
                {
                    Flip();
                }
                else if (moveH < 0 && facingRight)
                {
                    Flip();
                }

                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            else
            {
                anim.SetFloat("EnemySpeedH", 0);
                anim.SetFloat("EnemySpeedV", 0);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
