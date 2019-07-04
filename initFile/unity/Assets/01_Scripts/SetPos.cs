using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPos : MonoBehaviour
{
    public Vector2 pos;

    [ContextMenu("RePosition")]
    public void RePosition()
    {
        CanvasSize canvas = FindObjectOfType<CanvasSize>();
        RectTransform rectTr = transform as RectTransform;
        Vector2 pivot = rectTr.pivot;
        transform.position = new Vector2( pos.x + pivot.x * rectTr.sizeDelta.x, (canvas.transform.position.y * 2) - pos.y - pivot.y * rectTr.sizeDelta.y);
    }
}