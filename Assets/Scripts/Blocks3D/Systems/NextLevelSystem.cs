using Leopotam.Ecs;
using UnityEngine;

namespace cubes
{
    public class NextLevelSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;
        private StaticData _staticData = null;
        private CubePlatforms _cubePlatforms = null;
        private EcsFilter<NextLevelEvent> _filter = null;
        private EcsFilter<TimerComponent> _timerFilter = null;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var timer = ref _timerFilter.Get1(1);
                if (_sceneData.currentLevel > _staticData.levels.Length - 1)
                {
                    Debug.LogWarning("NO MORE LEVELS!!!");
                    timer.isGoing = false;
                    return;
                }
                _filter.GetEntity(i).Destroy();
                if (_staticData.levels[_sceneData.currentLevel].CubesCount == 4)
                {
                    _cubePlatforms.TwoByTwo.SetActive(true);
                    _cubePlatforms.ThreeByThree.SetActive(false);
                }
                else
                {
                    _cubePlatforms.ThreeByThree.SetActive(true);
                    _cubePlatforms.TwoByTwo.SetActive(false);
                }
                timer.timerImage.fillAmount = 1f;
                timer.isGoing = true;
                _world.NewEntity().Get<CubeInitEvent>();
            }
        }
    }
}
