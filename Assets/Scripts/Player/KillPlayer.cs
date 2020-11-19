using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public PlayerLives playerlives;
    public PlayerHealth playerHealth;
    public HealthController healthController;
    public GameObject player;

    public Animator anim;

    public bool playerOutOfBounds;

    void Update()
    {
        playerOutOfBounds = false;

        if (healthController.canRespawn)
        {
            player.transform.position = spawnPoint.position;
            anim.SetBool("Death", false);
            playerlives.currentPlayerLives -= 1;
            playerHealth.currentPlayerHealth = 100;
            healthController.canRespawn = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            playerOutOfBounds = true;
            playerlives.currentPlayerLives -= 1;
            playerHealth.currentPlayerHealth = 100;
            col.transform.position = spawnPoint.position;
        }
    }
}
