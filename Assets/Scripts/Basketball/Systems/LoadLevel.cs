using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class LoadLevel : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private SceneData _sceneData = null;
        private StaticData _staticData = null;

        private EcsFilter<BasketComponent> _basketAnimationFilter = null;
        private EcsFilter<LoadLevelEvent> _eventFilter = null;
        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                _eventFilter.GetEntity(i).Destroy();

                ref var animator = ref _basketAnimationFilter.Get1(1);

                if (_sceneData.CurrentLevel >= _staticData.Levels.Length)
                {
                    Debug.LogWarning("No more levels!");
                    _sceneData.CurrentLevel = 0;
                }

                switch (_staticData.Levels[_sceneData.CurrentLevel].Feature)
                {
                    case "Standart":
                        MoveToCenter();
                        animator.BasketAnimator.SetTrigger("MakeBasketStop");
                        break;
                    case "FromSide":
                        MoveToSide();
                        break;
                    case "MovingBasket":
                        MoveToSide();
                        animator.BasketAnimator.SetTrigger("MakeBasketMove");
                        break;
                    default:
                        break;
                }
            }
        }
        private void MoveToSide()
        {
            Camera.main.transform.position = _sceneData.CameraSpawnPoints[0].transform.position;
            Camera.main.transform.rotation = _sceneData.CameraSpawnPoints[0].transform.rotation;
            _sceneData.CurrentCameraPos = 0;
        }
        private void MoveToCenter()
        {
            Camera.main.transform.position = _sceneData.CameraSpawnPoints[2].transform.position;
            Camera.main.transform.rotation = _sceneData.CameraSpawnPoints[2].transform.rotation;
            _sceneData.CurrentCameraPos = 2;
        }
    }
}
