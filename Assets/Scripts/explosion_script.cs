using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class explosion_script : MonoBehaviour
{
    // declare the Animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();	// create the Animator component
    }

    // Update is called once per frame
    void Update()
    {
        //Explode = true
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Send the message to the Animator to activate the trigger parameter named "walk"
            anim.SetBool("Explode", true);
            Debug.Log("Exploding.");
        }
        //Explode = false
        if (Input.GetKeyUp(KeyCode.F))
        {
            //Send the message to the Animator to activate the trigger parameter named "walk"
            anim.SetBool("Explode", false);
            Debug.Log("Not Exploding.");
        }
    }
}
