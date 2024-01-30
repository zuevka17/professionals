using UnityEngine;
using Leopotam.Ecs;

public class EcsInit : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;

    private EcsWorld ecsWorld;
    private EcsSystems systems;
    void Start()
    {
        ecsWorld = new EcsWorld();
        systems = new EcsSystems(ecsWorld);

        systems
            .Add(new CubeInitSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Init();
    }

    void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        systems?.Destroy();
        systems = null;
        ecsWorld?.Destroy();
        ecsWorld = null;
    }
}
