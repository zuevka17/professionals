using Leopotam.Ecs;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CenterCheckSystem : IEcsRunSystem
{
    private EcsWorld _world;
    private EcsFilter<Cube, MovableComponent> filter;

    static private int count = 0;
    public void Run()
    {
        foreach(var i in filter)
        {

            ref var cube = ref filter.Get1(i);
            ref var movableComponent = ref filter.GetEntity(i);
            if ((cube.cubePosition.position.x == cube.finPoint.x) && (cube.cubePosition.position.z == cube.finPoint.z))
            {
                count++;
                movableComponent.Del<MovableComponent>();
            }
            if (count == 4)
            {
                ref var winEvent = ref _world.NewEntity().Get<WinEvent>();
                count = 0;
            }
        }
    }
}
