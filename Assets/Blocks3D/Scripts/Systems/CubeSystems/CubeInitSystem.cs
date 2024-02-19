using Leopotam.Ecs;
using UnityEngine;

public class CubeInitSystem : IEcsRunSystem
{
    private EcsWorld _ecsWorld = null;
    private StaticData _staticData = null;
    private SceneData _sceneData = null;
    private EcsFilter<Cube> _cubeFilter = null;
    private EcsFilter<CubeInitTrigger> _trigger;
    public void Run()
    {
        foreach (var i in _trigger)
        {
            _trigger.GetEntity(i).Destroy();

            foreach (var j in _cubeFilter)
            {
                ref var cube = ref _cubeFilter.Get1(j);
                Object.Destroy(cube.go);
                ref var entity = ref _cubeFilter.GetEntity(j);
                entity.Destroy();
            }
            for (int j = 0; j < _staticData.levels[_sceneData.currentLevel].CubesCount; j++)
            {
                EcsEntity cubeEnity = _ecsWorld.NewEntity();

                GameObject cubeGO = Object.Instantiate(_staticData.cubePrefab,
                    _staticData.levels[_sceneData.currentLevel].Cords.positions[j] + new Vector3(0, 0.5f, 0),
                    Quaternion.Euler(_staticData.levels[_sceneData.currentLevel].Rotations.rotationAngle[j]));

                ref var cube = ref cubeEnity.Get<Cube>();
                ref var movable = ref cubeEnity.Get<MovableComponent>();

                switch (cubeGO.transform.rotation.eulerAngles.y)
                {
                    case 0:
                        ref var leftComponent = ref cubeEnity.Get<LeftCubeMarker>();
                        break;
                    case 90:
                        ref var upComponent = ref cubeEnity.Get<UpCubeMarker>();
                        break;
                    case 180:
                        ref var rightComponent = ref cubeEnity.Get<RightCubeMarker>();
                        break;
                    case 270:
                        ref var downComponent = ref cubeEnity.Get<DownCubeMarker>();
                        break;
                }

                cube.go = cubeGO;

                movable.isCanMove = false;

                cube.cubePosition = cubeGO.gameObject.transform;

                if (_staticData.levels[_sceneData.currentLevel].CubesCount == 4)
                    cube.distanceToMove = 2.6f;
                else
                    cube.distanceToMove = 3.9f;
                cube.finPoint = new Vector3(cube.cubePosition.position.x + cube.cubePosition.forward.x * cube.distanceToMove,
                    cube.cubePosition.position.y + cube.cubePosition.forward.y * cube.distanceToMove,
                    cube.cubePosition.position.z + cube.cubePosition.forward.z * cube.distanceToMove);

                cube.cubeRigidbody = cubeGO.GetComponent<Rigidbody>();

                cube.test = cubeGO.GetComponent<ColliderTest>();
                cube.hasTouched = cube.test.touched;
            }
        }
    }
}
