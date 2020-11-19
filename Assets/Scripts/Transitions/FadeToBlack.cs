using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeToBlack : MonoBehaviour
{
    public Animator animator;
    public Animator portal_start_desert;
    public Animator portal_start_grasslands;

    public int timer;
    public bool startTimer;

    void Start()
    {
        timer = 0;
        startTimer = false;
    }
    void Update()
    {
        if (startTimer)
        {
            timer += 1;
        }

        if (timer > 20)
        {
            ClosePortals();

            timer = 0;
            startTimer = false;
        }
    }

    public void Crossfade_In()
    {
        animator.SetBool("In", true);
        animator.SetBool("Out", false);
    }

    public void Crossfade_Out()
    {
        animator.SetBool("Out", true);
        animator.SetBool("In", false);

        startTimer = true;
    }

    public void ClosePortals()
    {
        startTimer = true;
        portal_start_desert.SetBool("Close", true);
        portal_start_grasslands.SetBool("Close", true);
    }
}
