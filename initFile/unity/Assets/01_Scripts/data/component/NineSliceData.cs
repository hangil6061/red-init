using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NineSliceData : ComponentData
{ 
    public string key = "";
    public Vector3Data pivot;
    public Vector3Data size;
    public string color = "ffffff";
    public float alpha = 1;
    public int top;
    public int bottom;
    public int left;
    public int right;

    public NineSliceData(Image img) : base(img, "nineSlice")
    {
        if (img.sprite)
        {
            key = img.sprite.name;

            left = (int)img.sprite.border.x;        
            bottom = (int)img.sprite.border.y;        
            right = (int)img.sprite.border.z;
            top = (int)img.sprite.border.w;
        }
        pivot = new Vector3Data((img.transform as RectTransform).pivot);
        pivot.y = 1 - pivot.y;
        size = new Vector3Data((img.transform as RectTransform).sizeDelta);       
        color = Util.ColorToHex(img.color);
        alpha = img.color.a;
        
    }
}
