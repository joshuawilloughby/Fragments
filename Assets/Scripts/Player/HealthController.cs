using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;
    public PlayerLives playerLives;
    public Animator anim;

    public int timer;
    public bool startTimer;

    public bool canRespawn;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void Start()
    {
        timer = 0;
        startTimer = false;
        canRespawn = false;
    }

    void Update()
    {
        if (startTimer)
        {
            timer += 1;
        }

        if (playerHealth.currentPlayerHealth <= 0)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Death", true);
            Debug.Log("play death anim");
            startTimer = true;

            if (timer > 200)
            {
                anim.SetBool("Idle", true);
                anim.SetBool("Death", false);
                timer = 0;
                startTimer = false;
                canRespawn = true;
            }
        }

        if (playerHealth.currentPlayerHealth == 100)
        {
            slider.value = 100;
        }
    }
}
