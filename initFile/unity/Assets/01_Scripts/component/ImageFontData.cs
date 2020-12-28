using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFontData : ComponentData
{
    public Vector3Data pivot;
    public Dictionary<string, string> textures;
    public Dictionary<string, float> width;
    public Dictionary<string, float> height;

    public ImageFontData(ImageFont imgFont) : base(imgFont, "imageFont")
    {
        pivot = new Vector3Data(imgFont.pivot);
        textures = new Dictionary<string, string>();//imgFont.textures.Length + imgFont.strTex.Count];
        height = new Dictionary<string, float>();
        width = new Dictionary<string, float>();


        for ( int i = 0; i < imgFont.textures.Length; i++ )
        {
            textures.Add(i.ToString(), imgFont.textures[i].name);
        }

        for( int i = 0; i < imgFont.chars.Length; i++ )
        {
            textures.Add(imgFont.chars[i].ch, imgFont.chars[i].sp.name);
        }

        for (int i = 0; i < imgFont.chars.Length; i++)
        {
            width.Add(imgFont.chars[i].ch, imgFont.chars[i].size.x);
            height.Add(imgFont.chars[i].ch, imgFont.chars[i].size.y);
        }
    }
}
