using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

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

        //set SpeedH to the absolute value of moveH
        anim.SetFloat("SpeedH", Mathf.Abs(moveH));

        //set SpeedV to the value of moveV
        anim.SetFloat("SpeedV", moveV);

        //move
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveH * speed, moveV * speed);

        //check to see if the player needs to be flipped
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
