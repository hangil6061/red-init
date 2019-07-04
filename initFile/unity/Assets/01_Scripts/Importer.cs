using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

[System.Serializable]
public class ImgData
{
    public string name = "";
    public float x = 0;
    public float y = 0;
    public float width = 0;
    public float height = 0;

    public ImgData( string n, float x, float y, float w, float h )
    {
        name = n;
        this.x = x;
        this.y = y;
        width = w;
        height = h;
    }
}

public class Importer : MonoBehaviour {

    public RectTransform rc;
    public Sprite[] sprites;
    public TextAsset text;

    public List<ImgData> list = new List<ImgData>();

    [ContextMenu("LoadJson")]
    public void LoadJson()
    {
        JObject json = JObject.Parse(text.text);
        JToken images = json["skins"]["default"];
        list.Clear();

        foreach( var item in images )
        {
            foreach (var img in item)
            {
                JProperty jProperty = img.First as JProperty;
                JObject data = jProperty.Value as JObject;

                float x = float.Parse(data["x"].ToString());
                float y = float.Parse(data["y"].ToString());
                float width = float.Parse(data["width"].ToString());
                float height = float.Parse(data["height"].ToString());
                list.Add(new ImgData(jProperty.Name, x, y, width, height));
            }
        }

        Debug.Log(list);
    }

    [ContextMenu("CreateImage")]
    public void CreateImage()
    {
        CanvasSize canvas = FindObjectOfType<CanvasSize>();

        for ( int i = 0; i < list.Count; i++ )
        {
            ImgData data = list[i];

            GameObject go = new GameObject(data.name);            
            RectTransform rectTr = go.AddComponent<RectTransform>();
            rectTr.SetParent(rc);
            Image img = go.AddComponent<Image>();
            img.sprite = GetSprite(data.name);
            Vector2 pivot = rectTr.pivot;
            rectTr.sizeDelta = new Vector2(data.width, data.height);
            rectTr.position = new Vector2(data.x, (canvas.transform.position.y * 2) + data.y);
        }
    }

    private Sprite GetSprite( string name )
    {
        for( int i = 0; i < sprites.Length; i++ )
        {
            if( sprites[i].name == name )
            {
                return sprites[i];
            }
        }

        return null;
    }



}
