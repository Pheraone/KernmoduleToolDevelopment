using NaughtyAttributes;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueSetter : MonoBehaviour {

    [SerializeField] private ValueHolder valueHolder;
    public string path = "Assets/Testing/Values.json";

    public TMP_InputField inResolution;
    public TMP_InputField inNoiseScale;
    public TMP_InputField inSeed;
    public TMP_InputField inOctaves;
    public TMP_InputField inPersistance;
    public TMP_InputField inLacunarity;
    public TMP_InputField inOffsetX;
    public TMP_InputField inOffsetY;
    public TMP_InputField inPath;


    public Image img;

    public ValueHolder ValueHolder { get => valueHolder; set => valueHolder = value; }
    public NoiseTextureGenerator noiseTextureGenerator;
 
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

    //TEST
    //public void SetIntValue(TMP_InputField inputField, Values value) 
    //{
    //    var a = inputField.text;
    //    values.values = int.Parse( a );
    //}
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
    }

    public void SetPath()
    {
        var a = inPath.text;
        path = inPath.text;
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
        var a = inResolution.text;
        ValueHolder.Values.resolution = int.Parse(a);
    }

    public void SetNoiseScale()
    {
        var b = inNoiseScale.text;
        ValueHolder.Values.noiseScale = float.Parse(b);
    }

    public void SetSeed()
    {
        var c = inSeed.text;
        ValueHolder.Values.seed = int.Parse(c);
    }
   
    public void SetOctaves()
    {
        var c = inOctaves.text;
        ValueHolder.Values.octaves = int.Parse(c);
    }
    public void SetLacunarity()
    {
        var c = inLacunarity.text;
        ValueHolder.Values.lacunarity = int.Parse(c);
    }

    public void SetPersistance()
    {
        var c = inPersistance.text;
        ValueHolder.Values.persistance = int.Parse(c);
    }
     public void SetOffsetX()
    {
        var c = inOffsetX.text;
        ValueHolder.Values.offset.x = int.Parse(c);
    }
    public void SetOffsetY()
    {
        var c = inOffsetY.text;
        ValueHolder.Values.offset.y = int.Parse(c);
    }
}
