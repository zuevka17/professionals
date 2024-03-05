using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class BallToNextPosSystem : IEcsRunSystem
    {
        private EcsWorld _esWorld = null;
        private SceneData _sceneData = null;
        private StaticData _staticData = null;

        private EcsFilter<GoalEvent> _eventFilter = null;
        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                if (_staticData.Levels[_sceneData.CurrentLevel].Feature != "Standart")
                {
                    Camera.main.transform.position = _sceneData.CameraSpawnPoints[_sceneData.CurrentCameraPos].transform.position;
                    Camera.main.transform.rotation = _sceneData.CameraSpawnPoints[_sceneData.CurrentCameraPos].transform.rotation;
                    _sceneData.CurrentCameraPos++;
                }
                _eventFilter.GetEntity(i).Destroy();
            }
        }
    }
}
