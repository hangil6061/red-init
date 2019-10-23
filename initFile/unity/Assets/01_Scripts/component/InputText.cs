using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public int fontSize = 14;
    public Color fontColor = Color.black;
    public Color placeholderColor = Color.black;
    public string placeholder = "Enter text...";
    public InputField.ContentType contentType = InputField.ContentType.Standard;
    public InputField.LineType lineType = InputField.LineType.SingleLine;
    public TextAlignment textAlign = TextAlignment.Left;
    public Font font;
    public int maxLength = 0;

    private void Start()
    {
    }
}
