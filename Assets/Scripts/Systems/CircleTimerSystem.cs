using Leopotam.Ecs;
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

            timerComponent.timerImage = _ui.gameScreenScreenSpace.circleTimer;

            if (!timerComponent.isGoing)
                return;

            timerComponent.timerImage.fillAmount -= 0.001f;
            if (timerComponent.timerImage.fillAmount <= 0)
            {
                timerComponent.isGoing = false;
                ref var e = ref _world.NewEntity().Get<DefeatEvent>();
            }
        } 
    }
}
