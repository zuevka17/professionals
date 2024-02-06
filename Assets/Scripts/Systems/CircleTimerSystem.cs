using Leopotam.Ecs;
public class CircleTimerSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private UI _ui = null;

    public void Run()
    {
        var timer = _ui.gameScreenScreenSpace.circleTimer;
        timer.fillAmount -= 0.001f;
        if(timer.fillAmount <= 0)
        {
            ref var e = ref _world.NewEntity().Get<DefeatEvent>();
        }    
    }
}
