using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor;

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
    void Awake()
    {
        Debug.Log(this.transform.position);
        Debug.Log(GameObject.FindGameObjectWithTag("SpawnEntrance").transform.position);
        DontDestroyOnLoad(this);
        //transform.position.x = GameObject.FindGameObjectWithTag("SpawnEntrance").transform.position.x;
        //transform.position.y = GameObject.FindGameObjectWithTag("SpawnEntrance").transform.position.y;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        currentDirection = "right";
    }

    void Update()
    {
        //get input
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        //change health in the ui
        GameObject.FindGameObjectWithTag("UIHealth").GetComponent<Text>().text = "Health: " + health.ToString();

        //check if player is dead
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(2);
        }

        //if moving, check direction
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
        //check if player should be hit
        if (collision.gameObject.tag == "Enemy")
        {
            if (currentInvincibilityFrame == 0)
            {
                currentInvincibilityFrame = totalInvincibilityFrames;
                health -= collision.gameObject.GetComponent<EnemyAI>().damage;

                //find which direction the player was attacked from
                float xdif = transform.position.x - collision.transform.position.x;
                float ydif = transform.position.y - collision.transform.position.y;

                //knock enemy back
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xdif, ydif).normalized * 400);
            }
            else
            {
                currentInvincibilityFrame--;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //check if trigger is a door
        if (collision.gameObject.tag == "DoorNext" || collision.gameObject.tag == "LockedDoorNext")
        {
            if ((SceneManager.sceneCountInBuildSettings - 1) > SceneManager.GetActiveScene().buildIndex)
            {
                //load scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
        else if (collision.gameObject.tag == "DoorPrevious" || collision.gameObject.tag == "LockedDoorPrevious")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("test3");
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
