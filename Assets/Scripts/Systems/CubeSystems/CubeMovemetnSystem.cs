using Leopotam.Ecs;
using UnityEngine;
public class CubeMovemetnSystem : IEcsRunSystem
{
    private EcsWorld _world;
    private EcsFilter<Cube, MovableComponent> filter;
    //ѕеремещение куба на определенное рассто€ние.
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var cube = ref filter.Get1(i);
            ref var movableComponent = ref filter.Get2(i);
            if(movableComponent.isCanMove == true)
                cube.cubePosition.position = Vector3.MoveTowards(cube.cubePosition.position, cube.finPoint, 0.1f);
        }
    }

}