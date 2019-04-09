using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[Serializable]
public class GameObjectData
{
    public string name;
    public int instanceID;
    public bool isAcitive;
    public Vector3Data position;
    public Vector3Data scale;
    public Vector3Data rotation;
    public Vector3Data size;
    public List<GameObjectData> children = new List<GameObjectData>();
    public List<ComponentData> components = new List<ComponentData>();

    public GameObjectData( GameObject go )
    {
        name = go.name;
        instanceID = go.GetInstanceID();
        isAcitive = go.activeSelf;
        position = new Vector3Data(go.transform.localPosition);
        position.y *= -1;
        scale = new Vector3Data(go.transform.localScale);
        rotation = new Vector3Data(go.transform.localRotation.eulerAngles);
        size = new Vector3Data((go.transform as RectTransform).sizeDelta);

        Component[] comps = go.GetComponents(typeof(Component));
    
        for (int i = 0; i < comps.Length; i++)
        {
            ComponentData data = ComponentDataGenerator.CreateComponent(comps[i]);
            if( data != null )
            {
                components.Add(data);
            }
        }

        for (int i = 0; i < go.transform.childCount; i++)
        {
            children.Add(new GameObjectData(go.transform.GetChild(i).gameObject));
        }
    }
}