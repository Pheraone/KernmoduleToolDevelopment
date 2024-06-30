using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseValues : ICloneable
{
    public int resolution;
    public float noiseScale;
    public int octaves;
    [Range(0f, 1f)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;
    object ICloneable.Clone()
    {
        return new NoiseValues
        {
            resolution = this.resolution,
            noiseScale = this.noiseScale,
            octaves = this.octaves,
            persistance = this.persistance,
            lacunarity = this.lacunarity,
            seed = this.seed,
            offset = this.offset
        };
    }

    public NoiseValues Clone()
    {
        return (NoiseValues)((ICloneable)this).Clone();
    }
}
