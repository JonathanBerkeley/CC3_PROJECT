using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to maintain game settings through restarts etc
//Made following Unity official tutorial https://www.youtube.com/watch?v=uD7y4T4PVk0
public class GamePreferencesManager : MonoBehaviour
{
    public static GamePreferencesManager instance;

    const string MasterVolumeKey = "MasterVolume";
    const string EffectsVolumeKey = "EffectsVolume";
    const string FullscreenKey = "Fullscreen";
    const string MusicKey = "Music";
    const string ResolutionKey = "Resolution";

    //Game settings
    const string FOVKey = "FOV";
    const string BotCountKey = "BotCount";
    const string BleedKey = "BleedOn";
    const string HitsoundsKey = "HitsoundOn";

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        LoadPrefs();
    }

    //Hook to save preferences on quit
    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    //Save preferences to the registry
    //Also called by menu back button
    public void SavePrefs()
    {
        if (GlobalAudioReference.instance)
        {
            PlayerPrefs.SetFloat(MasterVolumeKey, GlobalAudioReference.instance.GetMasterVolume());
            PlayerPrefs.SetFloat(EffectsVolumeKey, GlobalAudioReference.instance.GetEffectsVolume());
        }

        PlayerPrefs.SetInt(MusicKey, MusicHandler.MusicSetting ? 1 : 0); //Music on main menu setting

        if (VideoSettings.instance)
        {
            PlayerPrefs.SetInt(FullscreenKey, VideoSettings.instance.GetFullscreen());
            PlayerPrefs.SetInt(ResolutionKey, VideoSettings.instance.GetResolution());
        }

        PlayerPrefs.SetInt(FOVKey, SettingsData.fovDesired);
        PlayerPrefs.SetInt(BotCountKey, SettingsData.botsDesired);
        PlayerPrefs.SetInt(BleedKey, SettingsData.bleedDesired ? 1 : 0);
        PlayerPrefs.SetInt(HitsoundsKey, SettingsData.hitsoundDesired ? 1 : 0);

        PlayerPrefs.Save();
    }

    //Load saved preferences from registry
    public void LoadPrefs()
    {
        if (GlobalAudioReference.instance)
        {
            //To make code neater
            var GAR = GlobalAudioReference.instance;

            GAR.SetMasterVolume(PlayerPrefs.GetFloat(MasterVolumeKey, GAR.GetMasterVolume()));
            GAR.SetEffectsVolume(PlayerPrefs.GetFloat(EffectsVolumeKey, GAR.GetEffectsVolume()));
        }

        MusicHandler.MusicSetting = PlayerPrefs.GetInt(MusicKey, 1) == 1; //Music on main menu setting

        if (VideoSettings.instance)
        {
            bool fsEnable = PlayerPrefs.GetInt(FullscreenKey, 0) != 0; // Defaults false

            VideoSettings.instance.ChangeFullscreen(fsEnable);
            VideoSettings.instance.ChangeResolution(PlayerPrefs.GetInt(ResolutionKey, 0));
        }

        SettingsData.fovDesired = PlayerPrefs.GetInt(FOVKey, 80);
        SettingsData.botsDesired = PlayerPrefs.GetInt(BotCountKey, 7);
        SettingsData.bleedDesired = PlayerPrefs.GetInt(BleedKey, 1) == 1; // Defaults true
        SettingsData.hitsoundDesired = PlayerPrefs.GetInt(HitsoundsKey, 1) == 1;
    }

    //Delete all saved preferences
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public int GetResEarly()
    {
        return PlayerPrefs.GetInt(ResolutionKey, 0);
    }
}
