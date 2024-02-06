using UnityEngine;
using Leopotam.Ecs;

public class EcsInit : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    public UI ui;

    private EcsWorld ecsWorld;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;
    private EcsSystems oneFrameSystems;
    void Start()
    {
        ecsWorld = new EcsWorld();

        updateSystems = new EcsSystems(ecsWorld);
        fixedUpdateSystems = new EcsSystems(ecsWorld);
        oneFrameSystems = new EcsSystems(ecsWorld);

        oneFrameSystems
            .Add(new CubeInitSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui);
        updateSystems
            .Add(new AllowCubeToMoveSystem())
            .Add(new CenterCheckSystem())
            .Add(new CubeDestroySystem())
            .Add(new DefeatSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui);
        fixedUpdateSystems
            .Add(new CircleTimerSystem())
            .Add(new CubeMovemetnSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui);
        oneFrameSystems.Init();
        updateSystems.Init();
        fixedUpdateSystems.Init();
    }

    void Update()
    {
        updateSystems.Run();
    }
    void FixedUpdate()
    {
        fixedUpdateSystems.Run();
    }

    public void OneFrameSystemsRun()
    {
        oneFrameSystems.Run();
    }
    private void OnDestroy()
    {
        updateSystems?.Destroy();
        updateSystems = null;

        fixedUpdateSystems?.Destroy();
        fixedUpdateSystems = null;

        oneFrameSystems?.Destroy();
        oneFrameSystems = null;

        ecsWorld?.Destroy();
        ecsWorld = null;
    }
 
}
