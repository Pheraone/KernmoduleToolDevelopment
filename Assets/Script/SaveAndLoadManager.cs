using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoadManager : MonoBehaviour
{
    public void SaveValues(ValueManager setter)
    {
        var holder = setter.ValueHolder;

        string json = JsonUtility.ToJson(holder.Values);
        File.WriteAllText(setter.path, json);
        Debug.Log("Data serialized to JSON successfully.");
    }

    public void LoadValues(ValueManager setter)
    {
        var holder = setter.ValueHolder;

        string json = File.ReadAllText(setter.path);
        holder.Values = JsonUtility.FromJson<NoiseValues>(json);
        setter.DataChanged();
    }
}

