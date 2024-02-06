using Leopotam.Ecs;
using UnityEngine;

public class CenterCheckSystem : IEcsRunSystem
{
    //ѕроверка достиг ли куб центра(просто тест)
    private EcsWorld _world;
    private EcsFilter<Cube> filter;
    public void Run()
    {
        foreach(var i in filter)
        {
            ref var cube = ref filter.Get1(i);
            if ((cube.cubePosition.position.x == cube.finPoint.x) && (cube.cubePosition.position.z == cube.finPoint.z))
                Debug.Log("ReachedPos");
        }
    }
}
