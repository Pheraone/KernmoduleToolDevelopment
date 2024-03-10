using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Values
{
    //put in a struct
   public int resolution;
    public float noiseScale;
 

    public int octaves;
    [Range(0f, 1f)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;
}
