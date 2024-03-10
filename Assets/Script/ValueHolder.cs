using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using UnityEditor;
using System.IO;
//using static System.Net.Mime.MediaTypeNames;

public class ValueHolder : MonoBehaviour
{
    public Image img;
    public MapGenerator generator;
    private Texture2D texture;

    private void Start()
    {
       texture = new Texture2D(values.resolution, values.resolution);
    }

    [SerializeField] string path = "Assets/Testing/Values.json";
    [SerializeField] private Values values;
    float[,] pixels;
    public Values Values
    {
        get => values;
        set
        {
            //OnValuesChanged();
            values = value;
        }
    }

  

    [Button("SET TEXTURE")]
    public void SetImage()
    {
       
        
        //for (int x = 0; x < Values.resolution; x++)
        //{
        //    for (int y = 0; y < Values.resolution; y++)
        //    {
        //        texture.SetPixel(x, y, new Color(pixels[x, y], pixels[x, y], pixels[x, y]));
        //    }
        //}
        texture = generator.GenerateMap(values.resolution, values.seed, values.noiseScale, values.octaves, values.persistance, values.lacunarity, values.offset) ;
        //display.DrawNoiseMap(pixels);
        texture.Apply();
        img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
    }

    [Button("EXPORT TEXTURE")]
    public void ExportImage()
    {
        //Texture2D texture = new Texture2D(Values.resolution, Values.resolution);
        //for (int x = 0; x < Values.resolution; x++)
        //{
        //    for (int y = 0; y < Values.resolution; y++)
        //    {
        //        texture.SetPixel(x, y, new Color(0, 1, 0));
        //    }
        //}
        //texture.Apply();
        //img;
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes( path, bytes);
        //Application.dataPath +
    }

    [Button("Save data.")]
    public void SerializeData()
    {
        var data = Values;
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(path, jsonData);
        Debug.Log("Data serialized to JSON successfully.");
    }

    // Deserialize the struct data from a JSON file
    [Button("Load data")]
    private void Deserialize()
    {
        Values = DeserializeData(path);
    }

    public Values DeserializeData(string path)
    {
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            Values data = JsonUtility.FromJson<Values>(jsonData);
            Debug.Log("Data deserialized from JSON successfully.");
            return data;
        }
        else
        {
            Debug.LogError("File not found for deserialization.");
            return new Values();
        }
    }
    //private void OnValuesChanged()
    //{

    //}

        private void OnValidate()
        {

            if (values.resolution < 1)
            {
                values.resolution = 1;
            }

            if (values.lacunarity < 1)
            {
                values.lacunarity = 1;
            }

            if (values.octaves < 0)
            {
                values.octaves = 0;
            }
        }
    }
