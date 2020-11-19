using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Initialise_UI : MonoBehaviour
{
    #region Public Variables
    public CameraFollower cameraFollower;

    public FadeToBlack crossFade;

    public GameObject TitleScreen;
    public GameObject In_Game_Options;
    public GameObject WorldSelect;
    public GameObject Paused;
    public GameObject DesertWorld;
    public GameObject GrasslandsWorld;
    public GameObject Updates;

    public GameObject player1;
    public GameObject player2;

    public Animator animF;
    public Animator animR;
    public Animator animA;
    public Animator animG;
    public Animator animM;
    public Animator animE;
    public Animator animN;
    public Animator animT;
    public Animator animS;

    public Animator startButton;
    public Animator updatesButton;

    public PlayerBase playerBase;
    public PlayerBase playerBase2;
    public Enemy_Behaviour enemyBehaviour;
    public Abilities abilities;
    public Abilities abilities2;

    public static string menu = "Title Screen Canvas";

    public bool startTimer;
    public bool startPausedTimer;
    public bool startDesertTransitionTimer;
    public bool startGrasslandsTransitionTimer;
    public bool startRestartLevelTransitionTimer;

    public bool gamePaused;
    public bool pause;
    public bool canPause;
    #endregion

    #region Private Variables
    private int timer;
    private int pausedTimer;
    private int desertTransitionTimer;
    private int grasslandsTransitionTimer;
    private int restartLevelTransitionTimer;
    #endregion
    void Start()
    {
        AnimateInTrue();

        timer = 0;
        pausedTimer = 0;
        desertTransitionTimer = 0;
        grasslandsTransitionTimer = 0;
        restartLevelTransitionTimer = 0;

        startTimer = false;
        startPausedTimer = false;
        startDesertTransitionTimer = false;
        startGrasslandsTransitionTimer = false;
        startRestartLevelTransitionTimer = false;

        canPause = false;
    }
    void Update()
    {
        if (startTimer)
        {
            timer += 1;
        }

        if (startPausedTimer)
        {
            pausedTimer += 1;
        }

        if (startDesertTransitionTimer)
        {
            desertTransitionTimer += 1;
        }

        if (startGrasslandsTransitionTimer)
        {
            grasslandsTransitionTimer += 1;
        }

        if (startRestartLevelTransitionTimer)
        {
            restartLevelTransitionTimer += 1;
        }

        if (menu == "Title Screen Canvas")
        {
            TitleScreen.SetActive(true);    // if we have chosen to view the "Title" menu, move the other menus offscreen
            Paused.SetActive(false);
            In_Game_Options.SetActive(false);
            WorldSelect.SetActive(false);
            DesertWorld.SetActive(false);
            GrasslandsWorld.SetActive(false);
        }

        if (timer > 150)
        {
            menu = "Desert";
            crossFade.ClosePortals();
            startTimer = false;
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            if (!Paused.activeSelf)
            {
                PauseButtonPressed();
                Paused.SetActive(true);
                return;
            }

            if (Paused.activeSelf)
            {
                ExitPauseMenu();
                Paused.SetActive(false);
                return;
            }
        }

        if (pausedTimer > 10)
        {
            menu = "Paused";
            startPausedTimer = false;
            pausedTimer = 0;
        }

        if (desertTransitionTimer > 150)
        {
            menu = "Desert";
            crossFade.Crossfade_Out();
            desertTransitionTimer = 0;
            startDesertTransitionTimer = false;
        }

        if (grasslandsTransitionTimer > 150)
        {
            menu = "Grasslands";
            crossFade.Crossfade_Out();
            grasslandsTransitionTimer = 0;
            startGrasslandsTransitionTimer = false;
        }

        if (restartLevelTransitionTimer > 50)
        {
            crossFade.Crossfade_Out();
            restartLevelTransitionTimer = 0;
            startRestartLevelTransitionTimer = false;
        }

        if (menu == "In-Game Options")
        {
            In_Game_Options.SetActive(true);
            Paused.SetActive(false);
            canPause = false;
        }

        if (menu == "World Select")
        {
            Paused.SetActive(false);
            WorldSelect.SetActive(true);
            canPause = false;
        }

        if (menu == "!World Select")
        {
            WorldSelect.SetActive(false);
        }

        if (menu == "Desert")
        {
            TitleScreen.SetActive(false);    // if we have chosen to view the "Title" menu, move the other menus offscreen
            Paused.SetActive(false);
            In_Game_Options.SetActive(false);
            WorldSelect.SetActive(false);
            DesertWorld.SetActive(true);
            GrasslandsWorld.SetActive(false);
            canPause = true;
            playerBase.player = player1;
        }

        if (menu == "Grasslands")
        {
            TitleScreen.SetActive(false);    // if we have chosen to view the "Title" menu, move the other menus offscreen
            Paused.SetActive(false);
            In_Game_Options.SetActive(false);
            WorldSelect.SetActive(false);
            DesertWorld.SetActive(false);
            GrasslandsWorld.SetActive(true);
            canPause = true;
            playerBase.player = player2;
        }

        if (menu == "Updates")
        {
            Updates.SetActive(true);
            TitleScreen.SetActive(false);
        }

        if (menu == "Paused")
        {
            Paused.SetActive(true);
            canPause = true;
        }

        if (!pause)
        {
            Paused.SetActive(false);
            gamePaused = false;
        }
    }

    void AnimateOutTrue()
    {
        animF.SetBool("Letter_F_Out", true);
        animR.SetBool("Letter_R_Out", true);
        animA.SetBool("Letter_A_Out", true);
        animG.SetBool("Letter_G_Out", true);
        animM.SetBool("Letter_M_Out", true);
        animE.SetBool("Letter_E_Out", true);
        animN.SetBool("Letter_N_Out", true);
        animT.SetBool("Letter_T_Out", true);
        animS.SetBool("Letter_S_Out", true);
        startButton.SetBool("Start_Out", true);
        updatesButton.SetBool("Updates_Out", true);
    }

    void AnimateInTrue()
    {
        animF.SetBool("Letter_F_In", true);
        animR.SetBool("Letter_R_In", true);
        animA.SetBool("Letter_A_In", true);
        animG.SetBool("Letter_G_In", true);
        animM.SetBool("Letter_M_In", true);
        animE.SetBool("Letter_E_In", true);
        animN.SetBool("Letter_N_In", true);
        animT.SetBool("Letter_T_In", true);
        animS.SetBool("Letter_S_In", true);
        startButton.SetBool("Start_In", true);
        updatesButton.SetBool("Updates_In", true);
    }

    public void StartButtonPressed()
    {
        AnimateOutTrue();
        startTimer = true;
        crossFade.ClosePortals();
    }

    public void UpdatesButtonPressed()
    {
        menu = "Updates";
    }

    public void PauseButtonPressed()
    {
        startPausedTimer = true;
        gamePaused = true;
        pause = true;
        Time.timeScale = 0;
    }

    public void ExitPauseMenu()
    {
        pause = false;
        Time.timeScale = 1;
        In_Game_Options.SetActive(false);
        Debug.Log(menu);
    }

    public void ExitWorldSelectMenu()
    {
        pause = false;
        Time.timeScale = 1;
        WorldSelect.SetActive(false);
        In_Game_Options.SetActive(false);
        Paused.SetActive(false);
        menu = "!World Select";
    }

    public void ToInGameOptionsMenu()
    {
        menu = "In-Game Options";
        Time.timeScale = 0;
    }

    public void ReturnToLevelSelect()
    {
        menu = "World Select";
    }

    public void WorldSelectDesert()
    {
        startDesertTransitionTimer = true;
        Time.timeScale = 1;
        crossFade.Crossfade_In();
        cameraFollower.target = player1.transform;
        pause = false;
    }

    public void WorldSelectGrasslands()
    {
        startGrasslandsTransitionTimer = true;
        Time.timeScale = 1;
        crossFade.Crossfade_In();
        cameraFollower.target = player2.transform;
        pause = false;
    }

    public void ReturnToPaused()
    {
        menu = "Paused";
        WorldSelect.SetActive(false);
        In_Game_Options.SetActive(false);
    }

    public void ReturnToTitle()
    {
        menu = "Title Screen Canvas";
        Updates.SetActive(false);
    }

    public void RestartLevel()
    {
        startRestartLevelTransitionTimer = true;
        crossFade.Crossfade_In();
        playerBase.StartState();
        playerBase2.StartState();
        enemyBehaviour.StartState();
        abilities.StartState();
        abilities2.StartState();
        ExitPauseMenu();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif 
    }
}
