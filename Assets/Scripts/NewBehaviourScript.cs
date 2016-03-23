using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    // Normal Movements Variables
    public float speed = 10;
    bool facingRight = true;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        anim.SetFloat("SpeedH", Mathf.Abs(moveH));
        anim.SetFloat("SpeedV", moveV);

        // Move senteces
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveH * speed, moveV * speed);

        if (moveH > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveH < 0 && facingRight)
        {
            Flip();
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
