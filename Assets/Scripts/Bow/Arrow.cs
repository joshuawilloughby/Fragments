using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHitPlatform;

    private bool platformTimerOn;
    private int platformTimer = 0;

    public PoisonArrow poisonArrow;
    public GameObject abilities;
    public GameObject abilities2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        platformTimer = 0;
        platformTimerOn = false;
    }

    void Update()
    {
        if (hasHitPlatform == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (platformTimerOn == true && hasHitPlatform == true)
        {
            platformTimer += 1;
            if (platformTimer > 50)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            hasHitPlatform = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            platformTimerOn = true;
        }

        if (collision.transform.CompareTag("MovingGround"))
        {
            hasHitPlatform = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            platformTimerOn = true;
        }

        if (collision.transform.CompareTag("KillFloor"))
        {
            hasHitPlatform = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            platformTimerOn = true;
        }

        if (collision.transform.CompareTag("Enemy"))
        {
            abilities = GameObject.Find("CORE/Menus/Levels/Desert/Canvases/Abilities Canvas");
            abilities2 = GameObject.Find("CORE/Menus/Levels/Grasslands/Canvases/Abilities Canvas");

            if (abilities.GetComponent<Abilities>().poisonShot || abilities2.GetComponent<Abilities>().poisonShot)
            {
                if (collision.transform.GetComponent<PoisonArrow>() != null)
                {
                    collision.transform.GetComponent<PoisonArrow>().ApplyPoison(20);
                }
                Destroy(gameObject);
            }
        }
    }
}
