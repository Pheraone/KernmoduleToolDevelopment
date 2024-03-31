using NaughtyAttributes;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueManager : MonoBehaviour {

    [SerializeField] private ValueHolder valueHolder;
    public string path = "Assets/Testing/Values.json";
    public string pathPNG = "Assets/Testing/Values.png";

    public TMP_InputField inResolution;
    public TMP_InputField inNoiseScale;
    public TMP_InputField inSeed;
    public TMP_InputField inOctaves;
    public TMP_InputField inPersistance;
    public TMP_InputField inLacunarity;
    public TMP_InputField inOffsetX;
    public TMP_InputField inOffsetY;
    public TMP_InputField inPath;
    public TMP_InputField inPathPNG;


    public Image img;

    public ValueHolder ValueHolder { get => valueHolder; set => valueHolder = value; }
    public NoiseTextureGenerator noiseTextureGenerator;

    private UndoRedoManager undoRedoManager = new UndoRedoManager();

    private void OnValuesChanged( )
    {
        inResolution.text = ValueHolder.Values.resolution.ToString();
        inNoiseScale.text = ValueHolder.Values.noiseScale.ToString();
        inSeed.text = ValueHolder.Values.seed.ToString();
        inPersistance.text = ValueHolder.Values.persistance.ToString();
        inLacunarity.text = ValueHolder.Values.lacunarity.ToString();
        inOffsetX.text = ValueHolder.Values.offset.x.ToString();
        inOffsetY.text = ValueHolder.Values.offset.y.ToString();
    }

    //If the value of the textfield is different from the value in the valueholder it will be adjusted to the right value
    public void DataChanged()
    {
        if (ValueHolder.Values.resolution.ToString() != inResolution.text)
        {
            inResolution.text = ValueHolder.Values.resolution.ToString();
        }
        if (ValueHolder.Values.noiseScale.ToString() != inNoiseScale.text)
        {
            inNoiseScale.text = ValueHolder.Values.noiseScale.ToString();
        }
        if (ValueHolder.Values.seed.ToString() != inSeed.text)
        {
            inSeed.text = ValueHolder.Values.seed.ToString();
        }
        if (ValueHolder.Values.octaves.ToString() != inOctaves.text)
        {
            inOctaves.text = ValueHolder.Values.octaves.ToString();
        } 
        if (ValueHolder.Values.persistance.ToString() != inPersistance.text)
        {
            inPersistance.text = ValueHolder.Values.persistance.ToString();
        }
        if (ValueHolder.Values.lacunarity.ToString() != inLacunarity.text)
        {
            inLacunarity.text = ValueHolder.Values.lacunarity.ToString();
        }
        if(ValueHolder.Values.offset.x.ToString() != inOffsetX.text)
        {
            inOffsetX.text = ValueHolder.Values.offset.x.ToString();
        }
        if(ValueHolder.Values.offset.y.ToString() != inOffsetY.text)
        {
            inOffsetY.text = ValueHolder.Values.offset.y.ToString();
        }
        SetImage();
    }

    public void SetPath()
    {
        var a = inPath.text;
        path = inPath.text;
    } 
    public void SetPathPNG()
    {
        var a = inPathPNG.text;
        pathPNG = inPathPNG.text;
    }

    [Button("SET TEXTURE")]
    public void SetImage()
    {
        ValueHolder.Texture = noiseTextureGenerator.GenerateMap(ValueHolder.Values);
        ValueHolder.Texture.Apply();
        img.sprite = Sprite.Create(ValueHolder.Texture, new Rect(0, 0, ValueHolder.Texture.width, ValueHolder.Texture.height), new Vector2(0.5f, 0.5f), 100);
    }


    public void SetResolution()
    {
       StorePreviousState();
        var a = inResolution.text;
        ValueHolder.Values.resolution = int.Parse(a);
        SetImage();
    }

    public void SetNoiseScale()
    {
        StorePreviousState();
        var a = inNoiseScale.text;
        ValueHolder.Values.noiseScale = float.Parse(a);
        SetImage();
    }

    public void SetSeed()
    {
        StorePreviousState();
        var a = inSeed.text;
        ValueHolder.Values.seed = int.Parse(a);
        SetImage();
    }
   
    public void SetOctaves()
    {
        StorePreviousState();
        var a = inOctaves.text;
        ValueHolder.Values.octaves = int.Parse(a);
        SetImage();
    }
    public void SetLacunarity()
    {
        StorePreviousState();
        var a = inLacunarity.text;
        ValueHolder.Values.lacunarity = int.Parse(a);
        SetImage();
    }

    public void SetPersistance()
    {
        StorePreviousState();
        var a = inPersistance.text;
        ValueHolder.Values.persistance = int.Parse(a);
        SetImage();
    }
     public void SetOffsetX()
    {
        StorePreviousState();
        var a = inOffsetX.text;
        ValueHolder.Values.offset.x = int.Parse(a);
        SetImage();
    }
    public void SetOffsetY()
    {
        StorePreviousState();
        var a = inOffsetY.text;
        ValueHolder.Values.offset.y = int.Parse(a);
        SetImage();
    }
   
    public void Undo()
    {
        NoiseValues previousValues = undoRedoManager.Undo(ValueHolder.Values);
        ApplyValues(previousValues);
    }

    public void Redo()
    {
        NoiseValues nextValues = undoRedoManager.Redo(ValueHolder.Values);
        ApplyValues(nextValues);
    }


    private void ApplyValues(NoiseValues updated)
    {
        ValueHolder.Values = updated;
        SetImage();
        DataChanged();
    }

    private void StorePreviousState()
    {
        undoRedoManager.StorePreviousState(ValueHolder.Values);
    }
}
