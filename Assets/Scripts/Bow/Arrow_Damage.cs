using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Damage : MonoBehaviour
{
    public Enemy_Health currentEnemyHealth;
    public PoisonArrow poisonArrow;
    public int damage;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Arrow"))
        {
            currentEnemyHealth.currentEnemyHealth -= damage;
            currentEnemyHealth.healthBar.SetHealth(currentEnemyHealth.currentEnemyHealth);
        }
    }
}
