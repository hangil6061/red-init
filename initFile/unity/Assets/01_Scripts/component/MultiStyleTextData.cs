using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StyleData
{
    public string name;
    public string font;
    public int fontSize;
    public string alignment;
    public string color;

    public StyleData( Style style )
    {
        name = style.name;
        font = style.font.name;
        fontSize = style.fontSize;
        alignment = style.alignment.ToString();
        color = Util.ColorToHex(style.color);
    }
}

[System.Serializable]
public class MultiStyleTextData : TextData {

    public StyleData[] styles;

    public MultiStyleTextData(Text text) : base(text)
    {
        name = "multiStyleText";

        MultiStyleText multiStyle = text.GetComponent<MultiStyleText>();

        if( multiStyle.styles.Length > 0 )
        {
            styles = new StyleData[multiStyle.styles.Length];
            for( int i = 0; i < styles.Length; i++ )
            {
                styles[i] = new StyleData(multiStyle.styles[i]);
            }
        }
    }
}
