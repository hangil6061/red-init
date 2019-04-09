using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CircleColliderData : ComponentData
{
    public bool isTrigger = false;
    public float radius;
    public Vector3Data offset;

    public CircleColliderData(CircleCollider2D collider) : base(collider, "circleCollider")
    {
        isTrigger = collider.isTrigger;
        radius = collider.radius;
        offset = new Vector3Data(collider.offset);
    }
}
