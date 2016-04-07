using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
    public Transform target;
    public int moveSpeed;
    public int viewDistance;
    public int health = 100;
    public int damage = 10;
    bool facingRight = true;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            float playerDistance = Mathf.Abs((target.position - transform.position).x) + Mathf.Abs((target.position - transform.position).y);

            if ((target != null) && (playerDistance <= viewDistance))
            {
                //Move Towards Target
                transform.position += (target.position - transform.position).normalized * moveSpeed * 0.005f;

                float moveH = (target.position - transform.position).normalized.x;
                float moveV = (target.position - transform.position).normalized.y;

                anim.SetFloat("EnemySpeedH", Mathf.Abs(moveH));
                anim.SetFloat("EnemySpeedV", moveV);

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
