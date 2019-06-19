using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTextData : ComponentData {

    public int targetText;
    public string key;

    public InitTextData(InitText text) : base(text, "initText")
    {
        targetText = text.targetText.GetInstanceID();
        key = text.key;
    }
}
