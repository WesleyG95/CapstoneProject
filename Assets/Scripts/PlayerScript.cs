using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10;
    public string currentDirection = "";
    public int health = 100;
    public int totalInvincibilityFrames = 10;
    int currentInvincibilityFrame = 0;
    bool facingRight = true;

    float moveH;
    float moveV;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentDirection = "right";
    }

    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (moveV != 0 || moveH != 0)
        {
            currentDirection = getDirection(moveH, moveV);
        }

        //set SpeedH to the absolute value of moveH
        anim.SetFloat("SpeedH", Mathf.Abs(moveH));

        //set SpeedV to the value of moveV
        anim.SetFloat("SpeedV", moveV);
    }

    void FixedUpdate()
    {

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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (currentInvincibilityFrame == 0)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                currentInvincibilityFrame = 10;
                health -= collision.gameObject.GetComponent<EnemyAI>().damage;

                float xdif = transform.position.x - collision.transform.position.x;
                float ydif = transform.position.y - collision.transform.position.y;

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xdif, ydif).normalized * 400);
            }
        }
        else
        {
            currentInvincibilityFrame--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("test");
            if (SceneManager.sceneCountInBuildSettings < EditorSceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
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
