using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteData : ComponentData
{
    public string key = "";
    public Vector3Data pivot;
    public Vector3Data size;
    public string color = "ffffff";
    public float alpha = 1;
    public bool isInteracive = false;

    public SpriteData(SpriteRenderer spr) : base(spr, "sprite")
    {
        key = spr.sprite.name;
    }

    public SpriteData(Image img) : base(img, "sprite")
    {
        if(img.sprite )
        {
            key = img.sprite.name;
        }
        pivot = new Vector3Data((img.transform as RectTransform).pivot);
        pivot.y = 1 - pivot.y;
        size = new Vector3Data((img.transform as RectTransform).sizeDelta);
        color = Util.ColorToHex( img.color );
        alpha = img.color.a;

        if( img.GetComponent<Interactive>() )
        {
            isInteracive = true;
        }

    }
}