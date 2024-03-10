using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    public bool autoUpdate;
    //public int seed { get { return values.seed; } set {  values.seed = value; } }

    public Texture2D GenerateMap(int resolution, int seed, float noiseScale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        Texture2D noiseTexture;
        float[,] noiseMap = Noise.GenerateNoiseMap(resolution, seed, noiseScale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        noiseTexture = display.DrawNoiseMap(noiseMap);
        return noiseTexture;
      
    }

    
    
}
