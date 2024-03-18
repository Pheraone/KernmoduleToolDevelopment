using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTextureGenerator : MonoBehaviour
{

    public Texture2D GenerateMap(NoiseValues values)
    {
        Texture2D noiseTexture;
        float[,] noiseMap = Noise.GenerateNoiseMap(values.resolution, values.seed, values.noiseScale, values.octaves, values.persistance, values.lacunarity, values.offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        noiseTexture = display.DrawNoiseMap(noiseMap);
        return noiseTexture;
    }
    
}
