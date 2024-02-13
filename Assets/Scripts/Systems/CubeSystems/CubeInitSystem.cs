using Leopotam.Ecs;
using UnityEngine;

public class CubeInitSystem : IEcsRunSystem
{
    private EcsWorld _ecsWorld = null;
    private StaticData _staticData = null;
    private SceneData _sceneData = null;
    private EcsFilter<Cube> _filter = null;
    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var cube = ref _filter.Get1(i);
            Object.Destroy(cube.go);
            ref var entity = ref _filter.GetEntity(i);
            entity.Destroy();
        }
        for (int i = 0; i < _sceneData.levelMassives[_sceneData.currentLevel].Length; i++)
        {
            //������� ecs ��������
            EcsEntity cubeEnity = _ecsWorld.NewEntity();
            //GameObject
            GameObject cubeGO = Object.Instantiate(_staticData.cubePrefab,
                _sceneData.levelMassives[_sceneData.currentLevel][i].position + new Vector3(0,0.5f,0),
                _sceneData.levelMassives[_sceneData.currentLevel][i].rotation.normalized);

            //���������� ���
            ref var cube = ref cubeEnity.Get<Cube>();
            //��������-���� ����������� ��� ����������� �������� ����
            ref var movable = ref cubeEnity.Get<MovableComponent>();
            //���������-������
            switch (_sceneData.spawnPoints[i].name.Remove(_sceneData.spawnPoints[i].name.Length - 1))
            {
                case "Left":
                    ref LeftCubeMarker cubeMarkerLeft = ref cubeEnity.Get<LeftCubeMarker>();
                    break;
                case "Right":
                    ref RightCubeMarker cubeMarkerRight = ref cubeEnity.Get<RightCubeMarker>();
                    break;
                case "Up":
                    ref UpCubeMarker cubeMarkerUp = ref cubeEnity.Get<UpCubeMarker>();
                    break;
                case "Down":
                    ref DownCubeMarker cubeMarkerDown = ref cubeEnity.Get<DownCubeMarker>();
                    break;
            }

            cube.go = cubeGO;

            //��������� �������� ����.
            movable.isCanMove = false;
            //��������� ���� ���������� ����
            cube.cubePosition = cubeGO.gameObject.transform;

            cube.distanceToMove = 3.9f; //or 2.6 for 2x2
            cube.finPoint = new Vector3(cube.cubePosition.position.x + cube.cubePosition.forward.x * cube.distanceToMove, 
                cube.cubePosition.position.y + cube.cubePosition.forward.y * cube.distanceToMove, 
                cube.cubePosition.position.z + cube.cubePosition.forward.z * cube.distanceToMove);

            cube.cubeRigidbody = cubeGO.GetComponent<Rigidbody>();

            cube.test = cubeGO.GetComponent<ColliderTest>();
            cube.hasTouched = cube.test.touched;
        }
    }
}
