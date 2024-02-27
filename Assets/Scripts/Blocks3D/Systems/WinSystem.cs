using Leopotam.Ecs;
using UnityEngine;
using System;

namespace cubes
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private StaticData _staticData = null;
        private SceneData _sceneData = null;
        private UI _ui = null;
        private EcsFilter<WinEvent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var winEvent = ref _filter.Get1(i);
                _ui.gameScreenScreenSpace.coinsLable.text = $"{Convert.ToInt32(_ui.gameScreenScreenSpace.coinsLable.text) + _staticData.rewardForLevel}";
                _filter.GetEntity(i).Destroy();
                Debug.Log("WinEvent hapens");

                _ui.gameScreenScreenSpace.currentLevel.text = (int.Parse(_ui.gameScreenScreenSpace.currentLevel.text) + 1).ToString();
                if (int.Parse(_ui.gameScreenScreenSpace.bestScore.text) < int.Parse(_ui.gameScreenScreenSpace.currentLevel.text))
                    _ui.gameScreenScreenSpace.bestScore.text = _ui.gameScreenScreenSpace.currentLevel.text;
                _sceneData.currentLevel++;

                StopCubeMovement();

                _world.NewEntity().Get<NextLevelEvent>();
            }
        }
        void StopCubeMovement()
        {
            _sceneData.isDownCubesMoves = false;
            _sceneData.isLeftCubesMoves = false;
            _sceneData.isRightCubesMoves = false;
            _sceneData.isUpCubesMoves = false;
        }
    }
}
