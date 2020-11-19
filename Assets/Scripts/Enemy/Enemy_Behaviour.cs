using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public bool playerDead;
    public Transform leftLimit;
    public Transform rightLimit;

    [Header("Desert Enemy Start Pos")]
    public float x;
    public float y;
    public float x2;
    public float y2;

    [Header("Grassland Enemy Start Pos")]
    public float x3;
    public float y3;
    public float x4;
    public float y4;

    [Header("Enemies")]
    public GameObject enemy_desert;
    public GameObject enemy_desert2;
    public GameObject enemy_grassland;
    public GameObject enemy_grassland2;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        playerDead = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!attackMode && !playerDead)
        {
            Move();
        }

        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            SelectTarget();
        }
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, rayCastMask);
            RaycastDebugger();
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            StopAttack();
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    public void Death()
    {
        playerDead = true;
        transform.position = transform.position;
        attackMode = false;
        anim.SetBool("Death", true);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }    
    }
    void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }    

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }    

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    public void StartState()
    {
        #region Enemy Variables
        //Starting enemies position
        enemy_desert.transform.position = new Vector3(x, y, 0);
        enemy_desert2.transform.position = new Vector3(x2, y2, 0);

        enemy_grassland.transform.position = new Vector3(x3, y3, 0);
        enemy_grassland2.transform.position = new Vector3(x4, y4, 0);

        Debug.Log("set enemy pos");

        //Starting enemies health 
        enemy_desert.GetComponent<Enemy_Health>().currentEnemyHealth = enemy_desert.GetComponent<Enemy_Health>().maxEnemyHealth;
        enemy_desert2.GetComponent<Enemy_Health>().currentEnemyHealth = enemy_desert2.GetComponent<Enemy_Health>().maxEnemyHealth;

        enemy_grassland.GetComponent<Enemy_Health>().currentEnemyHealth = enemy_grassland.GetComponent<Enemy_Health>().maxEnemyHealth;
        enemy_grassland2.GetComponent<Enemy_Health>().currentEnemyHealth = enemy_grassland2.GetComponent<Enemy_Health>().maxEnemyHealth;
        Debug.Log("set enemy health");

        //Respawn enemy (set as active)
        enemy_desert.GetComponent<Enemy_Behaviour>().playerDead = false;
        enemy_desert2.GetComponent<Enemy_Behaviour>().playerDead = false;

        enemy_grassland.GetComponent<Enemy_Behaviour>().playerDead = false;
        enemy_grassland2.GetComponent<Enemy_Behaviour>().playerDead = false;

        enemy_desert.SetActive(true);
        enemy_desert2.SetActive(true);

        enemy_grassland.SetActive(true);
        enemy_grassland2.SetActive(true);

        Debug.Log("set active");
        #endregion
    }
}
