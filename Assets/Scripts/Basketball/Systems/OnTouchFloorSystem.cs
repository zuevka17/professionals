using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class OnTouchFloorSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<TouchFloorEvent> _eventFilter = null;
        private EcsFilter<DestroyBallEvent> _destroyEventfilter = null;

        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                if(_destroyEventfilter.IsEmpty())
                {
                    ref var timer = ref _ecsWorld.NewEntity().Get<TimerComponent>();

                    timer.Type = TimerType.BallDestroy;
                    timer.StartTime = Time.time;
                    timer.TargetTime = timer.StartTime + 4f;

                    _ecsWorld.NewEntity().Get<DestroyBallEvent>();
                }

                _eventFilter.GetEntity(i).Destroy();
            }
        }
    }
}
