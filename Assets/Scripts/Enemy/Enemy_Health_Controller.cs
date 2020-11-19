using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health_Controller : MonoBehaviour
{
    public Slider slider;
    public Enemy_Health enemyHealth;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void Update()
    {
        slider.value = enemyHealth.currentEnemyHealth;
    }
}
