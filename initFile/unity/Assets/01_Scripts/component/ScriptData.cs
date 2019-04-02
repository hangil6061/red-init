using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScriptData : ComponentData
{
    public List<Prop_Number> numbers;
    public List<Prop_String> strings;
    public List<Prop_ReferenceData> references = new List<Prop_ReferenceData>();

    public ScriptData( Script scr ) : base( scr, scr.scriptName)
    {
        numbers = scr.numbers;
        strings = scr.strings;
        for( int i = 0; i < scr.references.Count; i++)
        {
            references.Add(new Prop_ReferenceData(scr.references[i]));
        }
    }
}
