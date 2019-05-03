using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntRectData
{
    public int x;
    public int y;
    public int w;
    public int h;

    public IntRectData(int x, int y, int w, int h)
    {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
    }
}
