using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Prop_Number
{
    public string name;
    public float value;
}

[System.Serializable]
public struct Prop_String
{
    public string name;
    public string value;
}

[System.Serializable]
public struct Prop_Reference
{
    public string name;
    public string componentName;
    public Object value;
}

[System.Serializable]
public struct Prop_ReferenceData
{
    public string name;
    public string componentName;
    public int instanceID;

    public Prop_ReferenceData(Prop_Reference propRef  )
    {
        name = propRef.name;
        componentName = propRef.componentName;
        instanceID = propRef.value.GetInstanceID();
    }
}

public class Script : MonoBehaviour
{
    public List<Prop_Number> numbers;
    public List<Prop_String> strings;
    public List<Prop_Reference> references;

    public string scriptName;
}
