﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class JointMenuInit : MonoBehaviour
{
    public static JointMenuInit instance;

    public Button[] uiButtons;
    public Button[] settingsButtons;
    public Button[] playButtons;
    public Button[] gamemodeButtons;

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playMenu;
    public GameObject gamemodeMenu;

    public AudioClip clickAudio;
    public float menuAudioVolume;

    public MenuCamera cameraScript;

    //Colours for fog true/false
    private Color buttonColorFalse = new Color32(164, 35, 35, 200);
    private Color buttonColorTrue = new Color32(75, 181, 75, 200);

    //For resetting camera speed
    private float previousCameraSpeed = 0.0f;

    //Find audio listener in scene (there should only be one)
    private AudioListener listener;

    void Awake()
    {
        //Make this a singleton class
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already in existence, destroying self");
            Destroy(this);
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        listener = GameObject.FindObjectOfType<AudioListener>();
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);
        gamemodeMenu.SetActive(false);

        //Sets up event listeners for main menu
        if (uiButtons.Length == 3)
        {
            Button btn = uiButtons[0].GetComponent<Button>();
            btn.onClick.AddListener(PlayButtonClicked);

            btn = uiButtons[1].GetComponent<Button>();
            btn.onClick.AddListener(SettingsButtonClicked);

            btn = uiButtons[2].GetComponent<Button>();
            btn.onClick.AddListener(ExitButtonClicked);
        }

        //Set up listeners for settings menu
        if (settingsButtons.Length == 1)
        {
            Button pbtn = settingsButtons[0].GetComponent<Button>();
            pbtn.onClick.AddListener(BackButtonClicked);
        }

        //Set up listeners for play menu
        if (playButtons.Length == 3)
        {
            Button pbtn = playButtons[0].GetComponent<Button>();
            pbtn.onClick.AddListener(Multiplayer);

            pbtn = playButtons[1].GetComponent<Button>();
            pbtn.onClick.AddListener(Singleplayer);

            pbtn = playButtons[2].GetComponent<Button>();
            pbtn.onClick.AddListener(BackButtonClicked);
        }

        //Set up listeners for gamemode menu
        if (gamemodeButtons.Length == 5)
        {
            Button gbtn = gamemodeButtons[0].GetComponent<Button>();
            gbtn.onClick.AddListener(Combat);

            gbtn = gamemodeButtons[1].GetComponent<Button>();
            gbtn.onClick.AddListener(Levels);

            gbtn = gamemodeButtons[2].GetComponent<Button>();
            gbtn.onClick.AddListener(Sandbox);

            gbtn = gamemodeButtons[3].GetComponent<Button>();
            gbtn.onClick.AddListener(Race);

            gbtn = gamemodeButtons[4].GetComponent<Button>();
            gbtn.onClick.AddListener(BackOneDepth);
        }
    }

    void Update()
    {
        //Shows cursor when returning from play
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Menu button functionality below

    void PlayButtonClicked()
    {
        MenuClickAudio();
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        playMenu.SetActive(true);
        previousCameraSpeed = cameraScript.GetCameraSpeed();
    }

    void SettingsButtonClicked()
    {
        MenuClickAudio();
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        settingsMenu.SetActive(true);
        previousCameraSpeed = cameraScript.SetRotateSpeed(-0.3f);
    }

    //Exit when button clicked. Also supports stopping editor.
    //Interesting reflection code for forcing editor to stop adopted from below link
    //http://answers.unity.com/answers/599597/view.html
    //This should also work for webplayer, whereas Application.Quit() does not.
    void ExitButtonClicked()
    {
        MenuClickAudio();
        if (Application.isEditor)
        {
            Type t = null;
            foreach (var assm in AppDomain.CurrentDomain.GetAssemblies())
            {
                t = assm.GetType("UnityEditor.EditorApplication");
                if (t != null)
                {
                    t.GetProperty("isPlaying").SetValue(null, false, null);
                    break;
                }
            }
        }
        else
        {
            Application.Quit();
        }
    }


    //Old settings menu buttons below (Now unused)

    void BotsButtonClicked()
    {
        MenuClickAudio();
        Text buttonText = settingsButtons[0].GetComponentInChildren<Text>();
        if (SettingsData.GetBotsDesired() < 7)
        {
            SettingsData.SetBotsDesired(SettingsData.GetBotsDesired() + 1);
        }
        else
        {
            SettingsData.SetBotsDesired(0);
        }
        buttonText.text = "Bots " + SettingsData.GetBotsDesired();
    }

    void FogButtonClicked()
    {
        MenuClickAudio();
        //Flips current setting
        SettingsData.SetFogDesired(!(SettingsData.GetFogDesired()));

        if (SettingsData.GetFogDesired())
        {
            settingsButtons[1].GetComponent<Image>().color = buttonColorTrue;
        }
        else
        {
            settingsButtons[1].GetComponent<Image>().color = buttonColorFalse;
        }
    }

    void BackButtonClicked()
    {
        MenuClickAudio();
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);
        mainMenu.SetActive(true);
        GamePreferencesManager.instance.SavePrefs(); // Saves settings to registry
        cameraScript.SetRotateSpeed(previousCameraSpeed);
    }

    void BackOneDepth()
    {
        MenuClickAudio();
        gamemodeMenu.SetActive(false);
        playMenu.SetActive(true);
    }

    //Play menu buttons below
    void Multiplayer()
    {
        MenuClickAudio();
        //Hides all the menus
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        playMenu.SetActive(false);

        SceneManager.LoadScene("MultiScene");
    }

    void Singleplayer()
    {
        MenuClickAudio();
        //Hides all the other menus
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        playMenu.SetActive(false);

        //Shows gamemode menu
        gamemodeMenu.SetActive(true);
    }


    //Gamemode menu button listeners below
    void Combat()
    {
        GamemodeClick();
        SceneManager.LoadScene("GameScene");
    }
    void Levels()
    {
        GamemodeClick();
        SceneManager.LoadScene("SampleScene");
    }

    void Sandbox()
    {
        GamemodeClick();
        SceneManager.LoadScene("SandBox");
    }

    void Race()
    {
        GamemodeClick();
        SceneManager.LoadScene("PvPCourse1");
    }


    void GamemodeClick()
    {
        MenuClickAudio();
        //Hides all the menus
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        gamemodeMenu.SetActive(false);
    }

    //Audio on menu
    void MenuClickAudio()
    {
        //Figures out menu camera position and plays sound at that location
        /* Legacy code
        Vector3 currentCameraPosition = Camera.main.transform.position;
        currentCameraPosition = (0.9f * currentCameraPosition) + (0.1f * transform.position);
        AudioSource.PlayClipAtPoint(clickAudio, currentCameraPosition, menuAudioVolume);
        */
        if (listener != null)
        {
            AudioSource.PlayClipAtPoint(clickAudio,
                listener.transform.position,
                menuAudioVolume
            );
        }

    }

    public AudioClip GetClickAudio()
    {
        return clickAudio;
    }

    public float GetMenuVolume()
    {
        return menuAudioVolume;
    }

    public void SetMenuVolume(float _vol)
    {
        menuAudioVolume = _vol;
    }
}
