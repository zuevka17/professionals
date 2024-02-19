using Leopotam.Ecs;

public class AllowCubeToMoveSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private SceneData _sceneData = null;
    
    //Фильтры для поска кубов каждой стороны
    private EcsFilter<LeftCubeMarker, MovableComponent> leftFilter;
    private EcsFilter<RightCubeMarker, MovableComponent> rightFilter;
    private EcsFilter<UpCubeMarker, MovableComponent> upFilter;
    private EcsFilter<DownCubeMarker, MovableComponent> downFilter;
    public void Run()
    {
        AllowToMove();
    }
    //Метод присваивающий значение компоненту-флагу каждого куба значение из SceneData
    private void AllowToMove()
    {
        foreach(var i in leftFilter)
        {
            ref var movableComponent = ref leftFilter.Get2(i);
            movableComponent.isCanMove = _sceneData.isLeftCubesMoves;
        }
        foreach (var i in rightFilter)
        {
            ref var movableComponent = ref rightFilter.Get2(i);
            movableComponent.isCanMove = _sceneData.isRightCubesMoves;
        }
        foreach (var i in upFilter)
        {
            ref var movableComponent = ref upFilter.Get2(i);
            movableComponent.isCanMove = _sceneData.isUpCubesMoves;
        }
        foreach (var i in downFilter)
        {
            ref var movableComponent = ref downFilter.Get2(i);
            movableComponent.isCanMove = _sceneData.isDownCubesMoves;
        }
    }
}
