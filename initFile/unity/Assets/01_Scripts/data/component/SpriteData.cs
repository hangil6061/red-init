using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteData : ComponentData
{
    public string key;
    public SpriteData(SpriteRenderer spr) : base(spr, "sprite")
    {
        key = spr.sprite.name;
    }

    public SpriteData(Image img) : base(img, "sprite")
    {
        key = img.sprite.name;
    }
}