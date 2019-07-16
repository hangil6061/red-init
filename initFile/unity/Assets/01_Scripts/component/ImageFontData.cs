using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFontData : ComponentData
{
    public Vector3Data pivot;
    public string[] textures;

    public ImageFontData(ImageFont imgFont) : base(imgFont, "imageFont")
    {
        pivot = new Vector3Data(imgFont.pivot);
        textures = new string[imgFont.textures.Length];
        for( int i = 0; i < textures.Length; i++ )
        {
            textures[i] = imgFont.textures[i].name;
        }
    }
}
