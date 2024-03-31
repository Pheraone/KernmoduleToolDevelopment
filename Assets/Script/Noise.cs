using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    //Code by Sebastian Lague
    public static float[,] GenerateNoiseMap(int resolution, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[resolution, resolution];

        System.Random rand = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];

        for(int i = 0; i< octaves; i++)
        {
            float offsetX = rand.Next(-100000, 100000) + offset.x;
            float offsetY = rand.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);  

        }

        if(scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float resolutionHalf = resolution / 2;    
        
        for(int y = 0; y < resolution; y++)
        {
            for(int x = 0; x < resolution; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for(int i = 0; i < octaves; i++)
                {
                    float sampleX = (x- resolutionHalf) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y- resolutionHalf) / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseMap[x, y] = perlinValue;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if(noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                } 
                else if(noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight;

            }
        }

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);

            }
        }
                return noiseMap;
    }
}

