using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;

    private new Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    public Initialise_UI initialise;
    public Bow bow;
    public AudioHandler audioHandler;
    public PoisonArrow poisonArrow;

    private int airJumpCount;
    public int airJumpCountMax;

    public Animator animator;

    public GameObject parent;

    public GameObject player;

    private void Awake()
    {
        //Get Components
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        airJumpCountMax = 1;
        animator.SetBool("Idle", true);
    }

    private void Update()
    {
        if (initialise.gamePaused)
        {
            return;
        }

        if (!initialise.gamePaused)
        {
            if (IsGrounded())
            {
                airJumpCount = 0;
            }

            //Jump 
            if (Input.GetKey(KeyCode.W))
            {
                if (IsGrounded())
                {
                    float jumpVelocity = 40f;
                    rigidbody2D.velocity = Vector2.up * jumpVelocity;
                }
                else
                {
                    //Double Jump
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        if (airJumpCount < airJumpCountMax)
                        {
                            audioHandler.PlayJumpSoundEffect();
                            float jumpVelocity = 40f;
                            rigidbody2D.velocity = Vector2.up * jumpVelocity;
                            airJumpCount++;
                        }
                    }
                }
            }

            //Call Movement Method
            HandleMovement_MidAirControl();
        } 
    }

    private bool IsGrounded()
    {
        //Checks to see if player is grounded
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement_MidAirControl()
    {
        float moveSpeed = 7f;
        float midAirControl = 3f;

        //Left Movement
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);

            //Flips player to the left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);

            if (IsGrounded())
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);

                if (!audioHandler.audiosource2.isPlaying)
                {
                    audioHandler.PlayWalkingSoundEffect();
                } 
            }
            else
            {
                rigidbody2D.velocity += new Vector2(-moveSpeed * midAirControl * Time.deltaTime, 0);
                rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveSpeed, +moveSpeed), rigidbody2D.velocity.y);

                audioHandler.audiosource2.Stop();
            }
        }
        else
        {
            //Right Movement
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", true);

                //Flips player to the right
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.eulerAngles = new Vector3(0, 0, 0);

                if (IsGrounded())
                {
                    rigidbody2D.velocity = new Vector2(+moveSpeed, rigidbody2D.velocity.y);

                    if (!audioHandler.audiosource2.isPlaying)
                    {
                        audioHandler.PlayWalkingSoundEffect();
                    }
                }
                else
                {
                    rigidbody2D.velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveSpeed, +moveSpeed), rigidbody2D.velocity.y);

                     audioHandler.audiosource2.Stop();
                }
            }
            else
            {
                //No keys are pressed
                if (IsGrounded())
                {
                    animator.SetBool("Idle", true);
                    animator.SetBool("Walk", false);
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                }
            }
        }
    }

    public void StartState()
    {
        #region Player Variables
        //Starting players position
        player.transform.position = new Vector3(-117, -1, 0);
        Debug.Log("set pos");

        //Starting players health 
        player.GetComponent<PlayerHealth>().currentPlayerHealth = player.GetComponent<PlayerHealth>().maxHealth;
        Debug.Log("set health");

        //Starting players lives
        player.GetComponent<PlayerLives>().currentPlayerLives = player.GetComponent<PlayerLives>().maxLives;
        Debug.Log("set lives");

        //Starting players ammo
        bow.ammo = 10;
        Debug.Log("set ammo");

        //Reset Poison effects
        poisonArrow.stopPoison = true;
        #endregion
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingGround"))
        {
            this.transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingGround"))
        {
            this.transform.SetParent(parent.transform);
        }
    }
}
