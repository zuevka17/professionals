using UnityEngine;
using System.IO;
using System;
using Leopotam.Ecs;

public class Parser : IEcsInitSystem
{
    private EcsWorld _world = null;
    private StaticData _data = null;
    public void Init()
    {
        ParseJsonAndImport();
    }

    void ParseJsonAndImport()
    {
        //json
        string file = Path.Combine("Assets/Resources/Data", "a1.json");
        string fileContent = File.ReadAllText(file);
        _data.levels = JsonHelper.FromJson<Level>(fileContent);

        System.Random random = new System.Random();
        random.Shuffle(_data.levels);
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
static class RandomExtensions
{
    public static void Shuffle<T>(this System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
