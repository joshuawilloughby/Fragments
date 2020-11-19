using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArrow : MonoBehaviour
{
    public Enemy_Health enemyHealth;
    public Abilities abilities;

    public bool stopPoison = false;

    public List<int> poisonTickTimers = new List<int>();

    void Start()
    {
        stopPoison = false;
        enemyHealth = GetComponent<Enemy_Health>();
    }

    void Update()
    {
        if (stopPoison)
        {
            poisonTickTimers.Clear();
            stopPoison = false;
        }
    }

    public void ApplyPoison(int ticks)
    {
        if (poisonTickTimers.Count <= 0)
        {
            poisonTickTimers.Add(ticks);
            StartCoroutine(Poison());
        }
        else
        {
            poisonTickTimers.Add(ticks);
        }
    }
    
    public IEnumerator Poison()
    {
        while (poisonTickTimers.Count > 0 && !stopPoison)
        {
            for (int i = 0; i < poisonTickTimers.Count; i++)
            {
                poisonTickTimers[i]--;
            }

            enemyHealth.currentEnemyHealth -= 1;
            poisonTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
