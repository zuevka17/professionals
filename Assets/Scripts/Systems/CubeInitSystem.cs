using Leopotam.Ecs;
using UnityEngine;

public class CubeInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    public void Init()
    {
        for(int i = 0; i < 4; i++)
        {
            EcsEntity cubeEnity = ecsWorld.NewEntity();

            GameObject cubeGO = Object.Instantiate(staticData.cubePrefab, sceneData.spawnPoints[i].position, Quaternion.identity);

            ref var cube = ref cubeEnity.Get<Cube>();

            cube.cubeRigidbody = cubeGO.GetComponent<Rigidbody>();
        }
    }
}
