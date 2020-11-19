using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth currentPlayerHealth;
    public int damage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && currentPlayerHealth.currentPlayerHealth > 0)
        {
            currentPlayerHealth.currentPlayerHealth -= damage;

            currentPlayerHealth.healthBar.SetHealth(currentPlayerHealth.currentPlayerHealth);
        }
        else
        {
            return;
        }
    }
}
