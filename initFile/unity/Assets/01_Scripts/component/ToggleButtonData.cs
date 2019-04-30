using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButtonData : ComponentData
{
    public int buttonSpriteintanceID;
    public int onInstanceID;
    public bool defaultValue;

    public ToggleButtonData(ToggleButton spr) : base(spr, "toggleButton")
    {
        buttonSpriteintanceID = spr.buttonImg.GetInstanceID();
        onInstanceID = spr.onGameObject.GetInstanceID();
        defaultValue = spr.onGameObject.activeSelf;
    }
}
