using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SFB; // Import Standalone File Browser package

public class ExportManager : MonoBehaviour
{
    public void ExportImage(ValueManager setter)
    {
        var holder = setter.ValueHolder;

        // Use Standalone File Browser to select save path
        string savePath = StandaloneFileBrowser.SaveFilePanel("Save PNG File", "", "exported_image", "png");

        if (!string.IsNullOrEmpty(savePath))
        {
            // Encode texture to PNG
            byte[] bytes = holder.texture.EncodeToPNG();

            // Write the PNG data to the selected path
            File.WriteAllBytes(savePath, bytes);
            Debug.Log("Image exported successfully to: " + savePath);
        }
        else
        {
            Debug.Log("Export cancelled or invalid path.");
        }
    }
}