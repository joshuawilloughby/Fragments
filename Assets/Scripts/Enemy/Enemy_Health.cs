using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxEnemyHealth = 100;
    public int currentEnemyHealth;

    public int timer;
    public bool startTimer;

    public Animator anim;

    public Enemy_Health_Controller healthBar;
    public Enemy_Behaviour enemyBehaviour;

    void Start()
    {
        timer = 0;
        currentEnemyHealth = maxEnemyHealth;
        healthBar.SetMaxHealth(maxEnemyHealth);
    }

    void Update()
    {
        if (startTimer)
        {
            timer += 1;
        }

        if (currentEnemyHealth <= 0)
        {
            enemyBehaviour.Death();
            startTimer = true;
        }

        if (timer == 100)
        {
            this.gameObject.SetActive(false);
            startTimer = false;
            timer = 0;
        }
    }
}
