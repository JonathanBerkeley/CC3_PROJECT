using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for transferring settings data across scenes
public static class SettingsData
{
    //Public so they can be set directly by GamePreferenceManager
    public static int botsDesired = 7;
    public static int fovDesired = 80;
    public static bool bleedDesired = true;
    public static bool hitsoundDesired = true;

    private static bool customBotOption = false;
    private static bool fogDesired = true;

    //Sets
    public static void SetBotsDesired(int b)
    {
        customBotOption = true;
        botsDesired = b;
    }
    
    public static void SetFogDesired(bool f)
    {
        fogDesired = f;
    }
    public static void SetFovDesired(int f)
    {
        fovDesired = f;
    }
    private static void SetCustomBotOption(bool cbo)
    {
        customBotOption = cbo;
    }


    //Gets
    public static int GetBotsDesired()
    {
        return botsDesired;
    }

    public static bool GetFogDesired()
    {
        return fogDesired;
    }

    public static int GetFovDesired()
    {
        return fovDesired;
    }

    //Returns false if no custom bot option being used
    public static bool GetCustomBotOption()
    {
        return customBotOption;
    }
}
