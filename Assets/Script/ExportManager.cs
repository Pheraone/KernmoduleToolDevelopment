using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExportManager : MonoBehaviour
{

    public void ExportImage(ValueManager setter)
    {
        var holder = setter.ValueHolder;

        byte[] bytes = holder.texture.EncodeToPNG();
        File.WriteAllBytes(setter.pathPNG, bytes);
    }
}
