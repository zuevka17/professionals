using UnityEngine;
using Leopotam.Ecs;

public class EcsInit : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    public UI ui;
    public CubePlatforms platforms;

    private EcsWorld _ecsWorld;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems;
    private EcsSystems _oneFrameSystems;
    void Start()
    {
        _ecsWorld = new EcsWorld();

        _updateSystems = new EcsSystems(_ecsWorld);
        _fixedUpdateSystems = new EcsSystems(_ecsWorld);
        _oneFrameSystems = new EcsSystems(_ecsWorld);

        _oneFrameSystems
            .Add(new StartGameSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui);
        _updateSystems
            .Add(new Parser())

            .Add(new CubeInitSystem())
            .Add(new ButtonsInitSystem())
            .Add(new AllowCubeToMoveSystem())
            .Add(new CenterCheckSystem())
            .Add(new CubeDestroySystem())
            .Add(new DefeatSystem())
            .Add(new WinSystem())
            .Add(new NextLevelSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(platforms)
            .Inject(ui);
        _fixedUpdateSystems
            .Add(new CircleTimerSystem())
            .Add(new CubeMovemetnSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui);

        _updateSystems.Init();
        _oneFrameSystems.Init();
        _fixedUpdateSystems.Init();
    }

    void Update()
    {
        _updateSystems.Run();
    }
    void FixedUpdate()
    {
        _fixedUpdateSystems.Run();
    }

    public void OneFrameSystemsRun()
    {
        _oneFrameSystems.Run();
    }
    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;

        _fixedUpdateSystems?.Destroy();
        _fixedUpdateSystems = null;

        _oneFrameSystems?.Destroy();
        _oneFrameSystems = null;

        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
 
}
