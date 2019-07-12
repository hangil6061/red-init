using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputTextData : ComponentData
{
    public string fontColor;
    public string placeholderColor;
    public string placeholder;
    public int fontSize;
    public string contentType;
    public string lineType;
    public float width;
    public float height;
    public Vector3Data pivot;
    public string textAlign;
    public string font;

    public InputTextData(InputText input) : base(input, "inputText")
    {
        fontColor = Util.ColorToHex(input.fontColor);
        placeholderColor = Util.ColorToHex(input.placeholderColor);
        placeholder = input.placeholder;
        fontSize = input.fontSize;
        contentType = input.contentType.ToString();
        lineType = input.lineType.ToString();
        width = (input.transform as RectTransform).sizeDelta.x;
        height = (input.transform as RectTransform).sizeDelta.y;
        pivot = new Vector3Data((input.transform as RectTransform).pivot);
        pivot.y = 1 - pivot.y;
        textAlign = input.textAlign.ToString().ToLower();
        if( input.font )
        {
            font = input.font.name;
        }
    }
}
