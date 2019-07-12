using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTextData : ComponentData
{
    public int textInstanceID = 0;
    public int buttonInstanceID = 0;
    public string enabledColor = "";
    public string disabledColor = "";

    public ButtonTextData(ButtonText text) : base(text, "buttonText")
    {
        textInstanceID = text.targetText.GetInstanceID();
        buttonInstanceID = text.targetButton.GetInstanceID();
        enabledColor = Util.ColorToHex(text.enabledColor);
        disabledColor = Util.ColorToHex(text.disabledColor);
    }
}
