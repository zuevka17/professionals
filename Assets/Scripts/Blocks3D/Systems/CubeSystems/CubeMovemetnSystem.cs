using Leopotam.Ecs;
using UnityEngine;

namespace cubes {
    public class CubeMovemetnSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<Cube, MovableComponent> _filter = null;
        //ѕеремещение куба на определенное рассто€ние.
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var cube = ref _filter.Get1(i);
                ref var movableComponent = ref _filter.Get2(i);
                if (movableComponent.isCanMove == true)
                    cube.cubePosition.position = Vector3.MoveTowards(cube.cubePosition.position, cube.finPoint, 0.1f);
            }
        }
    }
}