using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability_Cooldon_Timer : MonoBehaviour
{
    public Abilities abilities;
    public bool cooldownReset1;
    public bool cooldownReset2;
    public bool cooldownReset3;
    public float currentTime1;
    public float startingTime1;
    public float currentTime2;
    public float startingTime2;
    public float currentTime3;
    public float startingTime3;

    public Image abilityImage1;
    public Image abilityImage2;
    public Image abilityImage3;

    public Text countdownText1;
    public Text countdownText2;
    public Text countdownText3;
    void Start()
    {
        countdownText1.text = "";
        countdownText2.text = "";
        countdownText3.text = "";

        cooldownReset1 = false;
        cooldownReset2 = false;
        cooldownReset3 = false;

        currentTime1 = startingTime1;
        currentTime2 = startingTime2;
        currentTime3 = startingTime3;
    }

    void Update()
    {
        if (abilities.displayAbility1Cooldown)
        {
            currentTime1 -= 1 * Time.deltaTime;
            countdownText1.text = currentTime1.ToString("0") + "s";

            if (currentTime1 > 0)
            {
                abilityImage1.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
                cooldownReset1 = true;
                abilities.displayAbility1Cooldown = true;
            }

            if (currentTime1 <= 0)
            {
                countdownText1.text = "";
                abilityImage1.color = new Color(1, 1, 1);
                cooldownReset1 = false;
                abilities.displayAbility1Cooldown = false;
                currentTime1 = startingTime1;

                if (!abilities.abilityIsActive)
                {
                    abilities.abilityIsActive = false;
                }
            }
        }
        
        if (abilities.displayAbility2Cooldown)
        {
            currentTime2 -= 1 * Time.deltaTime;
            countdownText2.text = currentTime2.ToString("0") + "s";

            if (currentTime2 > 0)
            {
                abilityImage2.color = new Color(130f/255f, 130f / 255f, 130f / 255f);
                cooldownReset2 = true;
            }

            if (currentTime2 <= 0)
            {
                countdownText2.text = "";
                abilityImage2.color = new Color(1, 1, 1);
                cooldownReset2 = false;
                abilities.displayAbility2Cooldown = false;
                currentTime2 = startingTime2;

                if (!abilities.abilityIsActive)
                {
                    abilities.abilityIsActive = false;
                }
            }
        }

        if (abilities.displayAbility3Cooldown)
        {
            currentTime3 -= 1 * Time.deltaTime;
            countdownText3.text = currentTime3.ToString("0") + "s";

            if (currentTime3 > 0)
            {
                abilityImage3.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
                cooldownReset3 = true;
            }

            if (currentTime3 <= 0)
            {
                countdownText3.text = "";
                abilityImage3.color = new Color(1, 1, 1);
                cooldownReset3 = false;
                abilities.displayAbility3Cooldown = false;
                currentTime3 = startingTime3;

                if (!abilities.abilityIsActive)
                {
                    abilities.abilityIsActive = false;
                }
            }
        }
    }
}
