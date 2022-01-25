using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    public static VideoSettings instance;

    public Toggle fullScreen;
    public Toggle fog;
    public Dropdown resolution;

    private static bool fsInitial;
    private static int resInitial;

    void Start()
    {
        //Make singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already in existence, destroying self");
            Destroy(this);
        }

        fsInitial = Screen.fullScreen;
        resInitial = TranslateResolution(Screen.height);

        fullScreen.onValueChanged.AddListener(
            delegate 
            {
                MaintainSelections(0); 
            });

        resolution.onValueChanged.AddListener(
            delegate
            {
                MaintainSelections(2);
            });
    }

    private void Update()
    {
        fullScreen.isOn = fsInitial;
        resolution.value = resInitial;
    }

    private void MaintainSelections(int forObject)
    {
        switch (forObject)
        {
            case 0:
                //Fullscreen
                fsInitial = fullScreen.isOn;
                break;
            case 1:
                break;
            case 2:
                //Resolution
                resInitial = resolution.value;
                break;
            default:
                break;
        }
    }

    //Translates resolution to saveable value
    private int TranslateResolution(int _height)
    {
        switch (_height)
        {
            case 1080:
                return 0;
            case 720:
                return 1;
            case 600:
                return 2;
            default:
                return 0;
        }
    }

    //Changed dynamically by checkbox
    public void ChangeFullscreen(bool status)
    {
        Screen.fullScreen = status;
    }

    //Changed dynamically by dropdown
    public void ChangeResolution(int res)
    {
        switch (res)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(800, 600, Screen.fullScreen);
                break;
            default:
                break;
        }
        resInitial = res;
    }

    public int GetResolution()
    {
        return resInitial;
    }

    public int GetFullscreen()
    {
        return (fsInitial) ? 1 : 0;
    }
    
}
