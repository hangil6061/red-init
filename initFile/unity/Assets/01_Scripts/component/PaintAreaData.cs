using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintAreaData : ComponentData
{
    public Vector3Data pivot;
    public Vector3Data size;
    public string color = "ffffff";
    public int thickness = 1;

    public PaintAreaData(PaintArea paint) : base(paint, "paintArea")
    {
        size = new Vector3Data((paint.transform as RectTransform).sizeDelta);
        pivot = new Vector3Data((paint.transform as RectTransform).pivot);
        pivot.y = 1 - pivot.y;
        color = Util.ColorToHex(paint.color);
        thickness = paint.thickness;
    }
}
