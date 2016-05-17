using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
//using UnityEditor;

public class PlayerScript : MonoBehaviour
{
    public string direction = "forward";
    public float speed = 10;
    public string currentDirection = "";
    public int maxHealth = 100;
    public int health = 100;
    public int totalInvincibilityFrames = 10;
    int currentInvincibilityFrame = 0;
    bool facingRight = true;

    GameObject spawnEntrance;
    GameObject spawnExit;

    private static PlayerScript _instance;

    float moveH;
    float moveV;

    Animator anim;

    void OnLevelWasLoaded()
    {
        //LevelManager.setLastLevel();

        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            //find entrance and exit
            spawnEntrance = GameObject.FindGameObjectWithTag("SpawnEntrance");
            spawnExit = GameObject.FindGameObjectWithTag("SpawnExit");

            //move player to spawn location
            if (direction == "forward")
            {
                transform.position = new Vector3(spawnEntrance.transform.position.x, spawnEntrance.transform.position.y, spawnEntrance.transform.position.z);
            }
            else
            {
                transform.position = new Vector3(spawnExit.transform.position.x, spawnExit.transform.position.y, spawnExit.transform.position.z);
            }
        }
    }

    void Awake()
    {
        //check if there is another player in the scene
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            //destroy the other player in the scene
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        currentDirection = "right";
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
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
                SceneManager.LoadScene(2);
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
            LevelManager.setLastLevel(SceneManager.GetActiveScene().buildIndex);
            direction = "forward";
            RoomControl.loadNewScene(direction);
        }
        else if (collision.gameObject.tag == "DoorPrevious" || collision.gameObject.tag == "LockedDoorPrevious")
        {
            direction = "back";
            RoomControl.loadNewScene(direction);
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
