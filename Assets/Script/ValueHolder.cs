using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using UnityEditor;
using System.IO;
using TMPro;

public class ValueHolder : MonoBehaviour
{
    //public TMP_InputField inputField;
    //public Image img;
    //public NoiseTextureGenerator generator;
     public Texture2D texture;

    //private void Start()
    //{
    //   texture = new Texture2D(Values.resolution, Values.resolution);
    //}

    //[SerializeField] string path = "Assets/Testing/Values.json";
    [SerializeField, ReadOnly] private NoiseValues values;
    float[,] pixels;
    public NoiseValues Values
    {
        get => values;
        set
        {
            values = value;

        }
    }

    public Texture2D Texture { get => texture; set => texture = value; }
}

    //[Button("EXPORT TEXTURE")]
    //public void ExportImage()
    //{
    //    byte[] bytes = texture.EncodeToPNG();
    //    File.WriteAllBytes( path, bytes);
    //}

    //[Button("Save data.")]
    //public void SerializeData()
    //{
    //    var data = Values;
    //    string jsonData = JsonUtility.ToJson(data);
    //    File.WriteAllText(path, jsonData);
    //    Debug.Log("Data serialized to JSON successfully.");
    //}

    //// Deserialize the struct data from a JSON file
    //[Button("Load data")]
    //public void Deserialize()
    //{
    //    Values = DeserializeData(path);
    //}

    //public NoiseValues DeserializeData(string path)
    //{
    //    if (File.Exists(path))
    //    {
    //        string jsonData = File.ReadAllText(path);
    //        NoiseValues data = JsonUtility.FromJson<NoiseValues>(jsonData);
    //        Debug.Log("Data deserialized from JSON successfully.");
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("File not found for deserialization.");
    //        return new NoiseValues();
    //    }
    //}

    //private void OnValuesChanged()
    //{
    //    inputField.text = Values.resolution.ToString();
    //}

    //public void SetResolution()
    //{
    //    var a = inputField.text;
    //    Values.resolution = int.Parse(a);
    //}

    //private void OnValidate()
    //    {

    //        if (Values.resolution < 1)
    //        {
    //            Values.resolution = 1;
    //        }

    //        if (Values.lacunarity < 1)
    //        {
    //            Values.lacunarity = 1;
    //        }

    //        if (Values.octaves < 0)
    //        {
    //            Values.octaves = 0;
    //        }

    //        OnValuesChanged();
    //    }
    //}
