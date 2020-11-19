using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultSettings : MonoBehaviour
{
    public Slider soundtrackSlider, sfxSlider;
    private float soundtrackFloat, sfxFloat;

    public Toggle soundtrackToggle;
    public Toggle sfxToggle;

    //Contains a list of default values 
    public void Default()
    {
        soundtrackFloat = 0.25f;
        sfxFloat = 0.5f;
        soundtrackSlider.value = soundtrackFloat;
        sfxSlider.value = sfxFloat;
        soundtrackToggle.isOn = false;
        sfxToggle.isOn = false;
    }
}
