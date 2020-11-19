using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Toggle soundtrackToggle;
    public Toggle fxToggle;

    public AudioSource soundtrack;
    public AudioSource sfxs;
    public AudioSource jumpsfx;

    public static float soundtrackVol;
    public static float sfxVol;

    public static bool sfxOn = true;
    public static bool soundtrackOn = true;

    public void Start()
    {
        soundtrackVol = 0.25f;
        sfxVol = 0.5f;
    }
    public void OnSoundtrackValueChanged (float value)
    {
        if (soundtrackOn)
        {
            soundtrack.volume = value;
            soundtrackVol = value;
        }

        if (!soundtrackOn)
        {
            soundtrackVol = value;
        }
    }

    public void OnSFXValueChanged (float value)
    {
        if (sfxOn)
        {
            sfxs.volume = value;
            jumpsfx.volume = value;
            sfxVol = value;
        }

        if (!sfxOn)
        {
            sfxVol = value;
        }
    }

    public void OnSoundtrackToggleChanged(bool value)
    {
        if (value)
        {
            soundtrack.volume = 0;
            soundtrackOn = false;
        }

        if (!value)
        {
            soundtrack.volume = soundtrackVol;
            soundtrackOn = true;
        }
    }

    public void OnSFXToggleChanged(bool value)
    {
        if (value)
        {
            sfxs.volume = 0;
            jumpsfx.volume = 0;
            sfxOn = false;
        }

        if (!value)
        {
            sfxs.volume = sfxVol;
            jumpsfx.volume = sfxVol;
            sfxOn = true;
        }
    }

    public void ChangeScene_Start()
    {
        Initialise_UI.menu = "";
    }

    public void ChangeScene_Options()
    {
        Initialise_UI.menu = "Options";
    }
}
