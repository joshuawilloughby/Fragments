using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_handler : MonoBehaviour
{
    public GameObject lightning;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject clone;
            clone = Instantiate(lightning, transform.position, transform.rotation);
            StartCoroutine(LightningAnimation());
        }
    }

    IEnumerator LightningAnimation()
    {
        anim.SetBool("Lightning", true);
        yield return new WaitForSeconds(2.5f);
        Debug.Log("Animation Finished");
        anim.SetBool("Lightning", false);
    }
}

   
    