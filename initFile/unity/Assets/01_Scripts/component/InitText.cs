using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitText : MonoBehaviour {
    public Text targetText = null;
    public string key = "text_0";

    private void Reset()
    {
        if( targetText == null )
        {
            targetText = GetComponent<Text>();
        }
    }
}
