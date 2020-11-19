using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextLevel : MonoBehaviour
{
    public Initialise_UI initialise;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Initialise_UI.menu == "Desert")
            {
                initialise.WorldSelectGrasslands();
                return;
            }

            if (Initialise_UI.menu == "Grasslands")
            {
                return;
            }
        }
    }
}
