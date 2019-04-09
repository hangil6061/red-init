using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScrollData : ComponentData
{
    public int area;
    public int mask = 0;
    public int barBG = 0;
    public int bar = 0;
    public Vector3Data size;

    public ScrollData(Scroll scroll) : base(scroll, "scroll")
    {
        area = scroll.area.GetInstanceID();

        if ( scroll.mask != null)
        {
            mask = scroll.mask.GetInstanceID();
        }
        else
        {
            size = new Vector3Data((scroll.area.transform as RectTransform).sizeDelta);
        }

        if (scroll.barBG != null)
        {
            barBG = scroll.barBG.GetInstanceID();
        }

        if (scroll.bar != null)
        {
            bar = scroll.bar.GetInstanceID();
        }

    }
}
