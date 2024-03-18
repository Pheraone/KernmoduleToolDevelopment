using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoadManager : MonoBehaviour 
{
    public void SaveValues(ValueSetter setter)
    {
        var holder = setter.ValueHolder;

        string json = JsonUtility.ToJson(holder.Values);
        File.WriteAllText(setter.path, json);
        Debug.Log("Data serialized to JSON successfully.");
    }

    public void LoadValues(ValueSetter setter)
    {
        var holder = setter.ValueHolder;

        string json = File.ReadAllText(setter.path);
        holder.Values = JsonUtility.FromJson<NoiseValues>(json);
        setter.DataChanged();
    }

   
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

}

