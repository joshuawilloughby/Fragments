using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    #region Public Variables
    [Header("Audio Sources")]
    public AudioSource audiosource1;
    public AudioSource audiosource2;
    public AudioSource audiosource3;

    [Header("Soundtracks")]
    public AudioClip titleSoundtrack;
    public AudioClip desertSoundtrack;
    public AudioClip grasslandsSoundtrack;

    [Header("Flags")]
    public bool sfxOn = AudioController.sfxOn;
    public bool soundtrackOn = AudioController.soundtrackOn;
    public bool titleIsPlaying = false;
    public bool desertIsPlaying = false;
    public bool grasslandsIsPlaying = false;
    public bool canPlayDesertWalking = false;
    public bool canPlayGrasslandsWalking = false;

    [Header("Sound FX")]
    public AudioClip desertWalkingSFX;
    public AudioClip grasslandsWalkingSFX;
    public AudioClip menuClickSFX;
    public AudioClip menuSelectSFX;
    public AudioClip menuBackSFX;
    public AudioClip jumpSFX;
    #endregion

    void Start()
    {
        AudioController.soundtrackVol = 0.25f;
        AudioController.sfxVol = 0.5f;
    }
    #region SFX
    public void PlayWalkingSoundEffect()
    {
        if (sfxOn)
        {
            if (canPlayDesertWalking)
            {
                audiosource2.PlayOneShot(desertWalkingSFX, AudioController.sfxVol);
            }

            if (canPlayGrasslandsWalking)
            {
                audiosource2.PlayOneShot(grasslandsWalkingSFX, AudioController.sfxVol);
            }
        }

        if (!sfxOn)
        {
            return;
        }
    }

    public void PlayMenuClickSoundEffect()
    {
        if (sfxOn)
        {
            audiosource2.PlayOneShot(menuClickSFX, AudioController.sfxVol);
        }

        if (!sfxOn)
        {
            return;
        }
    }

    public void PlayMenuSelectSoundEffect()
    {
        if (sfxOn)
        {
            audiosource2.PlayOneShot(menuSelectSFX, AudioController.sfxVol);
        }

        if (!sfxOn)
        {
            return;
        }
    }

    public void PlayMenuBackSoundEffect()
    {
        if (sfxOn)
        {
            audiosource2.PlayOneShot(menuBackSFX, AudioController.sfxVol);
        }

        if (!sfxOn)
        {
            return;
        }
    }

    public void PlayJumpSoundEffect()
    {
        if (sfxOn)
        {
            audiosource3.PlayOneShot(jumpSFX, AudioController.sfxVol);
        }

        if (!sfxOn)
        {
            return;
        }
    }
    #endregion

    #region Soundtracks
    public void PlayTitleSoundtrack()
    {
        if (soundtrackOn)
        {
            titleIsPlaying = true;
            audiosource1.PlayOneShot(titleSoundtrack);
        }

        if (!soundtrackOn)
        {
            return;
        }
    }

    public void PlayDesertSoundtrack()
    {
        if (soundtrackOn)
        {
            desertIsPlaying = true;
            audiosource1.PlayOneShot(desertSoundtrack);
        }

        if (!soundtrackOn)
        {
            return;
        }
    }

    public void PlayGrasslandsSoundtrack()
    {
        if (soundtrackOn)
        {
            grasslandsIsPlaying = true;
            audiosource1.PlayOneShot(grasslandsSoundtrack);
        }

        if (!soundtrackOn)
        {
            return;
        }
    }
    #endregion

    void Update()
    {
        #region Title Soundtrack 
        if (Initialise_UI.menu == "Title Screen Canvas" && desertIsPlaying)
        {
            audiosource1.Stop();
            desertIsPlaying = false;
        }

        if (Initialise_UI.menu == "Title Screen Canvas" && grasslandsIsPlaying)
        {
            audiosource1.Stop();
            grasslandsIsPlaying = false;
        }

        if (Initialise_UI.menu == "Title Screen Canvas" && !audiosource1.isPlaying) 
        {
            Debug.Log("title");
            PlayTitleSoundtrack();
        }
        #endregion

        #region Desert Soundtrack
        if (Initialise_UI.menu == "Desert" && titleIsPlaying )
        {
            audiosource1.Stop();
            titleIsPlaying = false;
        }

        if (Initialise_UI.menu == "Desert" && grasslandsIsPlaying)
        {
            audiosource1.Stop();
            grasslandsIsPlaying = false;
        }

        if (Initialise_UI.menu == "Desert" && !audiosource1.isPlaying)
        {
            Debug.Log("desert");
            PlayDesertSoundtrack();
        }

        if (Initialise_UI.menu == "Desert")
        {
            canPlayDesertWalking = true;
            canPlayGrasslandsWalking = false;
        }
        #endregion

        #region Grasslands Soundtrack
        if (Initialise_UI.menu == "Grasslands" && titleIsPlaying)
        {
            audiosource1.Stop();
            titleIsPlaying = false;
        }

        if (Initialise_UI.menu == "Grasslands" && desertIsPlaying)
        {
            audiosource1.Stop();
            desertIsPlaying = false;
        }

        if (Initialise_UI.menu == "Grasslands" && !audiosource1.isPlaying)
        {
            Debug.Log("grasslands");
            PlayGrasslandsSoundtrack();
        }

        if (Initialise_UI.menu == "Grasslands")
        {
            canPlayGrasslandsWalking = true;
            canPlayDesertWalking = false;
        }
        #endregion
    }
}
