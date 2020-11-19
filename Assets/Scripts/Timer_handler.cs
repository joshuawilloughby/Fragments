using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_handler : MonoBehaviour
{
    private int timer = 0;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer > 96)
        {
            Destroy(gameObject);
        }

    }
}
