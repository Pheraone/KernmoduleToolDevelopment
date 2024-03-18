using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExportManager : MonoBehaviour
{

    //[Button("EXPORT TEXTURE")]
    public void ExportImage(ValueSetter setter)
    {
        var holder = setter.ValueHolder;

        byte[] bytes = holder.texture.EncodeToPNG();
        File.WriteAllBytes(setter.path, bytes);
    }
}
