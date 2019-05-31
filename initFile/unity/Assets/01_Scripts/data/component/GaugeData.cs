using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GaugeData : ComponentData
{
    public string key;
    public Vector3Data pivot;
    public Vector3Data size;
    public string color = "ffffff";
    public float alpha = 1;
    public string filledType = "horizontal";
    public string fillOrigin = "top";
    public bool fillClockwise = false;

    public GaugeData(Image img) : base(img, "gauge")
    {
        if (img.sprite)
        {
            key = img.sprite.name;
        }
        pivot = new Vector3Data((img.transform as RectTransform).pivot);
        pivot.y = 1 - pivot.y;
        size = new Vector3Data((img.transform as RectTransform).sizeDelta);
        color = Util.ColorToHex(img.color);
        alpha = img.color.a;

        if( img.fillMethod == Image.FillMethod.Radial360 )
        {
            filledType = "radial360";
            fillClockwise = img.fillClockwise;
        }

    }
}
