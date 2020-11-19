using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


// basic Animation script

public class Player_handler : MonoBehaviour
{
    
// declare the Animator
    private Animator anim;

    // handling projectile
    public GameObject bullet;
    public GameObject clone;
    int moveDirection = 1;
    int speed = 5;
    public float oldPos = 0.0f;
    public float currentPos = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();	// create the Animator component
    }
    void Update()
    {
        shootBullets();
        Movement();
    }

    void shootBullets()
    {
        // Ctrl or mouse button was pressed, launch a bullet
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire");
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation);

            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, -2 + 2, 0);

            // TO DO - set the bullet rotation,based on which way the player is facing
            if (moveDirection == 1)
            {
                rb.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (moveDirection == -1)
            {
                rb.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }
        
    }

    void Movement()
    {
        new Vector3();

        //Left movement
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveDirection = 0;
            Debug.Log("Not moving.");
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            //Send the message to the Animator to deactivate the trigger parameter named "Run"
            anim.SetBool("Run", false);

            //Send the message to the Animator to activate the trigger parameter named "Run"
            anim.SetBool("Idle", false);
        }

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveDirection = -1;
            Debug.Log("Moving to the left.");
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(0, 180, 0);
            //Send the message to the Animator to activate the trigger parameter named "Run"
            anim.SetBool("Run", false);

            //Send the message to the Animator to deactivate the trigger parameter named "Run"
            anim.SetBool("Idle", false);
        }

        //Right movement
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveDirection = 1;
            Debug.Log("Moving to the right.");
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.eulerAngles = new Vector3(0, 0, 0);
            //Send the message to the Animator to activate the trigger parameter named "Run"
            anim.SetBool("Run", false);

            //Send the message to the Animator to deactivate the trigger parameter named "Run"
            anim.SetBool("Idle", false);
        }

        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveDirection = 0;
            Debug.Log("Not moving.");
            //Send the message to the Animator to activate the trigger parameter named "walk"
            anim.SetBool("Run", false);

            //Send the message to the Animator to deactivate the trigger parameter named "other_walk"
            anim.SetBool("Idle", false);
        }

        //Up movement
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            //Send the message to the Animator to deactivate the trigger parameter named "walk"
            anim.SetBool("Jump", false);
            Debug.Log("Jumping.");

            //Send the message to the Animator to activate the trigger parameter named "other_walk"
            anim.SetBool("Idle", false);
        }

        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow)))
        {
            //Send the message to the Animator to deactivate the trigger parameter named "walk"
            anim.SetBool("Jump", false);

            //Send the message to the Animator to activate the trigger parameter named "other_walk"
            anim.SetBool("Idle", false);
            Debug.Log("Not moving.");
        }

        //Punching
        if (Input.GetKey(KeyCode.Q))
        {
            //Send the message to the Animator to deactivate the trigger parameter named "walk"
            anim.SetBool("Punch", false);
            Thread.Sleep(1000);
            anim.SetBool("Punch", false);
            


            //Send the message to the Animator to activate the trigger parameter named "other_walk"
            anim.SetBool("Idle", false);
            Thread.Sleep(1000);
            anim.SetBool("Idle", false);
        }


    }
}
