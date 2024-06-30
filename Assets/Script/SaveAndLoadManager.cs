using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SFB;

public class SaveAndLoadManager : MonoBehaviour
{
    public void SaveValues(ValueManager setter)
    {
        var holder = setter.ValueHolder;

        // Use standalone file browser to select save path
        string savePath = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "json");

        if (!string.IsNullOrEmpty(savePath))
        {
            string json = JsonUtility.ToJson(holder.Values);
            File.WriteAllText(savePath, json);
            Debug.Log("Data serialized to JSON successfully and saved to: " + savePath);
        }
    }

    public void LoadValues(ValueManager setter)
    {
        var holder = setter.ValueHolder;
        var extensions = new[]
        {
            new ExtensionFilter("Json Files", "json"),
            new ExtensionFilter("All Files", "*" ),
        };
        // Use standalone file browser to select load path
        var loadPaths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
        
        if (loadPaths.Length == 0)
        {
            return;
        }

        var loadPath = loadPaths[0];
        
        if (!string.IsNullOrEmpty(loadPath))
        {
            string json = File.ReadAllText(loadPath);
            holder.Values = JsonUtility.FromJson<NoiseValues>(json);
            setter.DataChanged();
            Debug.Log("Data loaded from: " + loadPath);
        }
    }
}