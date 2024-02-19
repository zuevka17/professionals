using Leopotam.Ecs;

public class CenterCheckSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private EcsFilter<Cube, MovableComponent> _filter = null;
    private SceneData _sceneData = null;
    private StaticData _staticData = null;

    static public int count = 0;
    public void Run()
    {
        foreach(var i in _filter)
        {
            ref var cube = ref _filter.Get1(i);
            ref var movableComponent = ref _filter.GetEntity(i);
            if ((cube.cubePosition.position.x == cube.finPoint.x) && (cube.cubePosition.position.z == cube.finPoint.z))
            {
                count++;
                movableComponent.Del<MovableComponent>();
            }
            if (count == _staticData.levels[_sceneData.currentLevel].CubesCount)
            {
                count = 0;
                _world.NewEntity().Get<WinEvent>();
            }
        }
    }
}
