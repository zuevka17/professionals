using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeInitSystem : IEcsRunSystem
{
    static bool hasBeenInstantiate = false;

    private EcsWorld _ecsWorld = null;
    private StaticData _staticData = null;
    private SceneData _sceneData = null;
    public void Run()
    {   
        if (hasBeenInstantiate)
            return;

        for(int i = 0; i < 4; i++)
        {
            //������� ecs ��������
            EcsEntity cubeEnity = _ecsWorld.NewEntity();

            //GameObject
            GameObject cubeGO = Object.Instantiate(_staticData.cubePrefab, 
                _sceneData.spawnPoints[i].position, 
                _sceneData.spawnPoints[i].rotation.normalized);

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

            cube.distanceToMove = 2.6f;
            cube.finPoint = new Vector3(cube.cubePosition.position.x + cube.cubePosition.forward.x * cube.distanceToMove, 
                cube.cubePosition.position.y + cube.cubePosition.forward.y * cube.distanceToMove, 
                cube.cubePosition.position.z + cube.cubePosition.forward.z * cube.distanceToMove);

            cube.cubeRigidbody = cubeGO.GetComponent<Rigidbody>();

            cube.test = cubeGO.GetComponent<ColliderTest>();
            cube.hasTouched = cube.test.touched;
        }
        hasBeenInstantiate = true;
    }
}
