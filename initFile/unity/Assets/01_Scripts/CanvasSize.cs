using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSize : MonoBehaviour {

    public static Canvas canvas;
    public void Reset()
    {
        canvas = GetComponent<Canvas>();
    }

    
}
