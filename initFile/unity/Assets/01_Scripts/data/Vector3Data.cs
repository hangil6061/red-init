using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vector3Data
{
    public float x;
    public float y;
    public float z;

    public Vector3Data(Vector3 vec3)
    {
        x = vec3.x;
        y = vec3.y;
        z = vec3.z;
    }
}