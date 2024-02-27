using UnityEngine;
using System.IO;
using System;
using Leopotam.Ecs;
using System.Linq;

namespace cubes
{
    public class Parser : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private StaticData _staticData = null;
        public void Init()
        {
            ParseJsonAndImport();
        }

        void ParseJsonAndImport()
        {
            //json
            string file = Path.Combine("Assets/Resources/Data", "Blocks3Dlevels.json");
            string fileContent = File.ReadAllText(file);
            _staticData.levels = JsonHelper.FromJson<Level>(fileContent);

            System.Random random = new System.Random();
            _staticData.levels = _staticData.levels.OrderBy(x => random.Next()).ToArray();
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
}