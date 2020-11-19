using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float useTime1;
    bool isCooldown1 = false;
    public KeyCode ability1;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float useTime2;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float useTime3;
    bool isCooldown3 = false;
    public KeyCode ability3;

    public Ability_Cooldon_Timer cooldownTimer;
    public bool displayAbility1Cooldown;
    public bool displayAbility2Cooldown;
    public bool displayAbility3Cooldown;

    public bool tripleShot;
    public bool unlimitedArrows;
    public bool poisonShot;

    public Initialise_UI initialise;

    public bool abilityIsActive;

    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        abilityIsActive = false;
        displayAbility1Cooldown = false;
        displayAbility2Cooldown = false;
        displayAbility3Cooldown = false;
    }

    void Update()
    {
        if (initialise.gamePaused)
        {
            return;
        }

        if (!initialise.gamePaused)
        {
            Ability1();
            Ability2();
            Ability3();
        }
    }

    #region UnlimitedArrows
    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown1 == false && !abilityIsActive && !cooldownTimer.cooldownReset1)
        {
            isCooldown1 = true;
            unlimitedArrows = true;
            abilityIsActive = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / useTime1 * Time.deltaTime;

            if (abilityImage1.fillAmount == 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
                unlimitedArrows = false;
                displayAbility1Cooldown = true;
                cooldownTimer.cooldownReset1 = true;
                abilityIsActive = false;
            }
        }
    }
    #endregion

    #region TripleShot
    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false && !abilityIsActive && !cooldownTimer.cooldownReset2)
        {
            isCooldown2 = true;
            tripleShot = true;
            abilityIsActive = true;
            abilityImage2.fillAmount = 1; 
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / useTime2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
                tripleShot = false;
                displayAbility2Cooldown = true;
                abilityIsActive = false;
                cooldownTimer.cooldownReset2 = false;
            }
        }
    }
    #endregion

    #region PoisonArrow
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false && !abilityIsActive && !cooldownTimer.cooldownReset3)
        {
            isCooldown3 = true;
            poisonShot = true;
            abilityIsActive = true;
            abilityImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / useTime3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
                poisonShot = false;
                displayAbility3Cooldown = true;
                abilityIsActive = false;
                cooldownTimer.cooldownReset3 = false;
            }
        }
    }
    #endregion

    public void StartState()
    {
        #region Variables

        #region Cooldowns
        isCooldown1 = false;
        isCooldown2 = false;
        isCooldown3 = false;
        #endregion

        #region Cooldown Reset
        cooldownTimer.cooldownReset1 = false;
        cooldownTimer.cooldownReset2 = false;
        cooldownTimer.cooldownReset3 = false;

        cooldownTimer.currentTime1 = cooldownTimer.startingTime1;
        cooldownTimer.currentTime2 = cooldownTimer.startingTime2;
        cooldownTimer.currentTime3 = cooldownTimer.startingTime3;

        cooldownTimer.countdownText1.text = "";
        cooldownTimer.abilityImage1.color = new Color(1, 1, 1);

        cooldownTimer.countdownText2.text = "";
        cooldownTimer.abilityImage2.color = new Color(1, 1, 1);

        cooldownTimer.countdownText3.text = "";
        cooldownTimer.abilityImage3.color = new Color(1, 1, 1);
        #endregion

        #region Images
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        #endregion

        #region Display Abilites
        abilityIsActive = false;
        displayAbility1Cooldown = false;
        displayAbility2Cooldown = false;
        displayAbility3Cooldown = false;
        #endregion

        #region Abilities
        tripleShot = false;
        unlimitedArrows = false;
        poisonShot = false;
        #endregion

        #endregion
    }
}
