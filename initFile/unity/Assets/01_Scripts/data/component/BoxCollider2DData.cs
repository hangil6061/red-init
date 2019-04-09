using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxCollider2DData : ComponentData
{
    public bool isTrigger = false;
    public Vector3Data size;
    public Vector3Data offset;

    public BoxCollider2DData(BoxCollider2D collider) : base(collider, "boxCollider")
    {
        isTrigger = collider.isTrigger;
        size = new Vector3Data( collider.size );
        offset = new Vector3Data( collider.offset );
    }
}
