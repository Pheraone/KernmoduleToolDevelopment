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
 
     public Texture2D texture;

   
    [SerializeField, ReadOnly] private NoiseValues values;
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

    