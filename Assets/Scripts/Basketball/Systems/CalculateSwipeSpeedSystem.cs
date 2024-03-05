using Leopotam.Ecs;
using UnityEngine;

namespace basketball { 
public class CalculateSwipeSpeed : IEcsRunSystem, IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private EcsFilter<SwipeComponent> _filter;
    public void Init()
    {
        var entity = _ecsWorld.NewEntity();
        ref var swipeComponent = ref entity.Get<SwipeComponent>();
    }
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var swipeComponent = ref _filter.Get1(i);

                swipeComponent.MaxSpeed = 0.25f;

                if (Input.GetMouseButtonDown(0))
                {
                    swipeComponent.StartPos = Input.mousePosition;
                    swipeComponent.StartTime = Time.time;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    swipeComponent.EndPos = Input.mousePosition;
                    swipeComponent.EndTime = Time.time;

                    swipeComponent.DeltaPos = swipeComponent.EndPos.y - swipeComponent.StartPos.y;
                    swipeComponent.DeltaTime = swipeComponent.EndTime - swipeComponent.StartTime;

                    swipeComponent.FinalSpeed = swipeComponent.DeltaPos / swipeComponent.DeltaTime / 10000;
                    if (swipeComponent.FinalSpeed > swipeComponent.MaxSpeed)
                    {
                        swipeComponent.FinalSpeed = swipeComponent.MaxSpeed;
                    }

                    _ecsWorld.NewEntity().Get<AddForceEvent>();

                }
            }
        }
    }
}
