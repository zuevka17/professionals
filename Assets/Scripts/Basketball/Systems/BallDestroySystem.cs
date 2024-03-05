using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class BallDestroySystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private SceneData _sceneData = null;

        private EcsFilter<DestroyBallEvent> _eventFilter = null;
        private EcsFilter<BallComponent> _ballFilter = null;
        private EcsFilter<TimerComponent> _timerFilter = null;

        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                ref var timer = ref _timerFilter.Get1(1);

                if (Time.time >= timer.TargetTime && timer.Type == TimerType.BallDestroy)
                {
                    _eventFilter.GetEntity(i).Destroy();

                    ref var ballComponent = ref _ballFilter.Get1(0);

                    ballComponent.BallRigidbody.isKinematic = true;
                    ballComponent.BallRigidbody.useGravity = false;

                    ballComponent.BallRigidbody.velocity = Vector3.zero;

                    ballComponent.GO.transform.position = _sceneData.SpawnPoint.transform.position;
                    ballComponent.GO.transform.rotation = Quaternion.identity;

                    foreach (var j in _timerFilter)
                    {
                        _timerFilter.GetEntity(j).Destroy();
                    }
                }
            }
        }
    }
}
