using cubes;
using Leopotam.Ecs;
using System.IO;

namespace basketball {
    public class Parser : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private StaticData _staticData = null;
        public void Init()
        {
            string file = Path.Combine("Assets/Resources/Data", "BaskeballLevel.json");
            string fileContent = File.ReadAllText(file);
            _staticData.Levels = JsonHelper.FromJson<Level>(fileContent);
        }
    }
}
