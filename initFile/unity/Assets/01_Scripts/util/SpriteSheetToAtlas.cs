using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class AtlasData
{
    public Dictionary<string, AtlasSpriteData> frames = new Dictionary<string, AtlasSpriteData>();
    public AtlasMetaData meta = new AtlasMetaData();

    public AtlasData( string img, int w, int h )
    {
        meta.image = img;
        meta.size = new Int2Data(w, h);
    }
}

[System.Serializable]
public class AtlasMetaData
{
    public string app = "https://ftredblog.wordpress.com/";
    public string version = "FROMtheRed AtlasMaker Tool v0.1.0";
    public string image;
    public Int2Data size;
    public float scale = 1;
}


[System.Serializable]
public class AtlasSpriteData
{
    public IntRectData frame;
    public bool rotated = false;
    public bool trimmed = false;
    public IntRectData spriteSourceSize;
    public Int2Data sourceSize;   

    public AtlasSpriteData( int x, int y, int w, int h )
    {
        frame = new IntRectData(x, y, w, h);
        spriteSourceSize = new IntRectData(0, 0, w, h);
        sourceSize = new Int2Data(w, h);
    }
}


public class SpriteSheetToAtlas : MonoBehaviour
{
    public string savePath;
    public Sprite[] sprites;

    [ContextMenu("ToAtlas")]
    public void ToAtlas()
    {
        if (sprites.Length <= 0) return;

        var texture = sprites[0].texture;
        AtlasData atlasData = new AtlasData(texture.name + ".png", texture.width, texture.height);

        int texHeight = texture.height;
        for ( int i = 0; i < sprites.Length; i++ )
        {
            Rect rect = sprites[i].rect;
            AtlasSpriteData spriteData = new AtlasSpriteData((int)rect.x, ( texHeight - (int)rect.y) - (int)rect.height, (int)rect.height, (int)rect.width );
            atlasData.frames.Add(sprites[i].name, spriteData);
        }


        string filePath = EditorUtility.SaveFolderPanel("save", savePath, "");
        if (filePath == string.Empty) return;
        savePath = filePath + "/"; ;

        string json = JsonConvert.SerializeObject(atlasData);
        Util.FileIO.WriteData(json, texture.name + ".json", true, savePath);
    }
}
