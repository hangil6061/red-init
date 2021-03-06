﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextData : ComponentData
{
    public string text = "";
    public string font = "";
    public int fontSize = 0;
    public string fontStyle = "";
    public string alignment = "";
    public string color = "";
    public int width = 0;
    public Vector3Data pivot;
    public float strokeThickness = 0;
    public string strokeColor = "";
    public int lineHeight = 0;

    public string dropShadowColor = "";
    public float dropShadowDistance = 0;


    public TextData(Text text) : base(text, "text")
    {
        this.text = text.text;
        this.font = text.font.name;
        this.fontSize = text.fontSize;
        this.alignment = text.alignment.ToString();
        this.color = Util.ColorToHex(text.color);
        this.width = (int)text.rectTransform.sizeDelta.x;
        this.pivot = new Vector3Data((text.transform as RectTransform).pivot);
        this.pivot.y = 1 - this.pivot.y;
        this.lineHeight = Mathf.RoundToInt(text.lineSpacing * this.fontSize * 1.13f);
        this.fontStyle = text.fontStyle.ToString();

        Outline outline = text.GetComponent<Outline>();
        if( outline )
        {
            this.strokeThickness = outline.effectDistance.x;
            this.strokeColor = Util.ColorToHex(outline.effectColor);
        }

        Shadow shadow = text.GetComponent<Shadow>();
        if( shadow )
        {
            this.dropShadowColor = Util.ColorToHex(shadow.effectColor);
            this.dropShadowDistance = shadow.effectDistance.x;
        }

    }
}