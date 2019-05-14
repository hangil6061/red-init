using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Style
{
    public string name;
    public Font font;
    public int fontSize;
    public TextAnchor alignment;
    public Color color;
}

public class MultiStyleText : MonoBehaviour {
    public Style[] styles;
}
