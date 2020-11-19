using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text healthText;
    public bool displayInfo;

    void Start()
    {
        displayInfo = false;
        healthText.text = "";
    }

    void Update()
    {
        displayHealth();
    }
    void OnMouseOver()
    {
        displayInfo = true;
    }

    void OnMouseExit()
    {
        displayInfo = false;
    }

    void displayHealth()
    {
        if (displayInfo)
        {
            healthText.text = playerHealth.currentPlayerHealth.ToString("0") + "/100";
        }
    }
}
