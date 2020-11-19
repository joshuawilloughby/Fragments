using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentPlayerHealth;

    public HealthController healthBar;
    public KillPlayer killPlayer;

    void Start()
    {
        currentPlayerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {  

    }
}
