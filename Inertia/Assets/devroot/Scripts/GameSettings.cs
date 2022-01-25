using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//For game tab on settings menu
public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    public Slider[] sliders;
    public GameObject tooltip;
    public float TooltipHideTime = 2.0f;
    public Toggle[] toggles;

    private static List<Coroutine> coroutines = new List<Coroutine>();

    private Text tooltipText;

    private void Awake()
    {
        tooltip.SetActive(false);
    }

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

        if (sliders.Length == 2)
        {
            // Field of view
            sliders[0].value = SettingsData.GetFovDesired();
            // Number of bots
            sliders[1].value = SettingsData.GetBotsDesired();
        }

        if (toggles.Length == 2)
        {
            // Bleed visuals
            toggles[0].isOn = SettingsData.bleedDesired;
            // Hitsounds
            toggles[1].isOn = SettingsData.hitsoundDesired;
        }

        tooltipText = tooltip.GetComponentInChildren<Text>();
    }

    //Controlled by UI slider in game menu (Float to int conversion due to Unity's slider implementation)
    public void BotDynamicSlider(float _bots)
    {
        SettingsData.SetBotsDesired((int)_bots);
        DisplayTooltip(SettingsData.GetBotsDesired().ToString());
    }

    public void FOVDynamicSlider(float _fov)
    {
        SettingsData.SetFovDesired((int)_fov);
        DisplayTooltip(SettingsData.GetFovDesired().ToString());
    }

    public void BleedDynamicSet(bool _set)
    {
        SettingsData.bleedDesired = _set;
    }

    public void HitsoundDynamicSet(bool _set)
    {
        SettingsData.hitsoundDesired = _set;
    }

    //Shows the tooltip for the current slider value
    public void DisplayTooltip(string _text)
    {
        if (_text == null)
            return;

        //Kill previous coroutines
        foreach (var co in coroutines)
            StopCoroutine(co);

        if (tooltipText != null)
            tooltipText.text = _text;
        else
            return;
        
        tooltip.SetActive(true); // Show tooltip

        //Begin coroutine to hide the tooltip after some time
        Coroutine _hideTooltip = StartCoroutine(HideTooltip());
        coroutines.Add(_hideTooltip);

        //Put tooltip at mouse position
        Vector3 _mousePosition = Input.mousePosition;
        tooltip.transform.position = new Vector3(
            _mousePosition.x,
            _mousePosition.y,
            _mousePosition.z
        );
    }

    IEnumerator HideTooltip()
    {
        yield return new WaitForSeconds(TooltipHideTime);
        tooltip.SetActive(false);
    }
}
