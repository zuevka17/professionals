using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class Parser : MonoBehaviour
{
    public Level[] levels;
    void Awake()
    {
        ParseJsonAndImport();
    }

    void ParseJsonAndImport()
    {
        string file = Path.Combine("Assets/Resources/Data", "a1.json");
        string fileContent = File.ReadAllText(file);
        Level[] levels = JsonHelper.FromJson<Level>(fileContent);
        this.levels = levels;
    }
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
