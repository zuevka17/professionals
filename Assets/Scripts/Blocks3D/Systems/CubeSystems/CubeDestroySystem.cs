using Leopotam.Ecs;

namespace cubes
{
    public class CubeDestroySystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<Cube> _filter = null;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var cube = ref _filter.Get1(i);

                cube.hasTouched = cube.test.touched;

                if (cube.hasTouched)
                {
                    ref var e = ref _world.NewEntity().Get<DefeatEvent>();

                    UnityEngine.Object.Destroy(cube.go);
                    _filter.GetEntity(i).Destroy();
                }
            }
        }
    }
}
