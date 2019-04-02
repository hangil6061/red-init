using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComponentData
{
    public string name;
    public int instanceID;

    public ComponentData(Component comp, string name)
    {
        this.name = name;
        instanceID = comp.GetInstanceID();
    }
}