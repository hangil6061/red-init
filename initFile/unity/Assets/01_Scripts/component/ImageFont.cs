using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ImageFontChar {
    public string ch;
    public Sprite sp;
}

public class ImageFont : MonoBehaviour {
    public Vector2 pivot = new Vector2( 0.5f, 0.5f );
    public Sprite[] textures;
    public ImageFontChar[] chars;
}
