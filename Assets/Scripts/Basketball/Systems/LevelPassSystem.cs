using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class LevelPassSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private SceneData _sceneData = null;
        private StaticData _staticData = null;

        private EcsFilter<ScoreComponent> _filter;
        public void Run()
        {
            ref var score = ref _filter.Get1(1);
            if (_staticData.Levels[_sceneData.CurrentLevel].Goal == score.LevelScore)
            {
                score.LevelScore = 0;
                _ecsWorld.NewEntity().Get<LoadLevelEvent>();
                
                Debug.Log("Load next level");

                _sceneData.CurrentLevel++;
            }
        }
    }
}
