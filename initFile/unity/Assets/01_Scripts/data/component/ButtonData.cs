using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : ComponentData
{
    public int imageInstanceID = 0;
    public string transition = "";

    public string normalSprite = "";
    public string highlightedSprite = "";
    public string pressedSprite = "";
    public string disabledSprite = "";

    public string normalColor = "";
    public string highlightedColor = "";
    public string pressedColor = "";
    public string disabledColor = "";

    public ButtonData(Button button) : base(button, "button")
    {
        imageInstanceID = button.targetGraphic.GetInstanceID();
        transition = button.transition.ToString();

        Debug.Log( transition );
        
        switch ( button.transition )
        {
            case Selectable.Transition.None:
                break;
            case Selectable.Transition.SpriteSwap:
                normalSprite = button.targetGraphic.mainTexture.name;
                highlightedSprite = button.spriteState.highlightedSprite.name;
                pressedSprite = button.spriteState.pressedSprite.name;
                if(button.spriteState.disabledSprite)
                {
                    disabledSprite = button.spriteState.disabledSprite.name;
                }                
                break;
            case Selectable.Transition.ColorTint:
                normalColor = Util.ColorToHex( button.colors.normalColor );
                highlightedColor = Util.ColorToHex(button.colors.highlightedColor );
                pressedColor = Util.ColorToHex(button.colors.pressedColor );
                disabledColor = Util.ColorToHex(button.colors.disabledColor );
                break;
            case Selectable.Transition.Animation:
                break;
        }


        
    }
}
