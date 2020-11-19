using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    private Animator anim;

    public AudioClip jumpAudio;
    public AudioClip walkAudio;
    public AudioClip landAudio;
    public AudioSource source;
    public float jumpVelocity = 60;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float moveSpeed = 5f;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps = 1;
    public int extraJumpsValue = 1;

    public CameraShake cameraShake;

    Rigidbody2D rb;

    void Start()
    {
        Debug.Log("Starting Up");
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        source.Pause();
    }
    void Awake()
    {

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        //Death animation
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(DeathAnimation());
        }

        //Sword swing animation
        if ((Input.GetMouseButtonDown(0)) && (isGrounded == true))
        {
            StartCoroutine(SwordAnimation());
        }

        //Extra jumps
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0))
        {
            fallMultiplier = 2.5f;
            rb.velocity = Vector2.up * jumpVelocity;
            extraJumps--;
            source.PlayOneShot(jumpAudio);
        }
        else if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true))
        {
            fallMultiplier = 2.5f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Slam down

        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded == false))
        {
            rb.velocity = Vector2.down * jumpVelocity;
            source.PlayOneShot(landAudio);
        }

        // flip left
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow) && isGrounded == true))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            source.PlayOneShot(walkAudio);
        }

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow) && isGrounded == false))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow) && isGrounded == true))
        {

        }

        // flip right
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow) && isGrounded == true))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            source.PlayOneShot(walkAudio);
        }

        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow) && isGrounded == false))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow) && isGrounded == true))
        {

        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (isGrounded = false && (col.transform.CompareTag("Ground")))
        {
            StartCoroutine(cameraShake.Shake(.1f, .4f));
        }
    }

    IEnumerator DeathAnimation()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Player died");
        anim.SetBool("Death", false);
        anim.SetBool("Idle", true);
    }

    IEnumerator SwordAnimation()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("SwordSwing", true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Animation Finished");
        anim.SetBool("SwordSwing", false);
        anim.SetBool("Idle", true);
    }
}
   