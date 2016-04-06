using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10;
    public string currentDirection = "";
    bool facingRight = true;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentDirection = "right";
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        if (moveV != 0 || moveH != 0)
        {
            currentDirection = getDirection(moveH, moveV);
        }

        //set SpeedH to the absolute value of moveH
        anim.SetFloat("SpeedH", Mathf.Abs(moveH));

        //set SpeedV to the value of moveV
        anim.SetFloat("SpeedV", moveV);

        //move
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveH * speed, moveV * speed);

        //check to see if the player needs to be flipped
        if (currentDirection == "right" || currentDirection == "left")
        {
            if (moveH > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveH < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            if (!facingRight)
            {
                Flip();
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

    string getDirection(float moveH, float moveV)
    {
        string direction = "";
        
        if (moveH < 0)
        {
            direction = "left";
        }
        else if (moveH == 0 && moveV > 0)
        {
            direction = "up";
        }
        else if (moveH == 0 && moveV < 0)
        {
            direction = "down";
        }
        else
        {
            direction = "right";
        }

        return direction;
    }
}
