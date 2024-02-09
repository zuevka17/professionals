using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;
public class CircleTimerSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private UI _ui = null;

    private EcsFilter<TimerComponent> _filter = null;

    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var timerComponent = ref _filter.Get1(1);

            if (!timerComponent.isGoing)
                return;

            var timer = _ui.gameScreenScreenSpace.circleTimer;
            timer.fillAmount -= 0.001f;
            if (timer.fillAmount <= 0)
            {
                timerComponent.isGoing = false;
                ref var e = ref _world.NewEntity().Get<DefeatEvent>();
            }
        } 
    }
}
