using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Hooks the base class of slider selectables to add new functionality
//used for displaying tooltips in settings menu
public class SliderHook : MonoBehaviour, IPointerDownHandler
{
    public int sliderID;

    void IPointerDownHandler.OnPointerDown(PointerEventData _data)
    {
        if (GameSettings.instance == null)
            return;

        switch (sliderID)
        {
            case 0:
                GameSettings.instance.DisplayTooltip(SettingsData.GetFovDesired().ToString());
                break;
            case 1:
                GameSettings.instance.DisplayTooltip(SettingsData.GetBotsDesired().ToString());
                break;
            default:
                return;
        }
    }
}
