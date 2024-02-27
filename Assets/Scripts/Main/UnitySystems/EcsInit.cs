using Leopotam.Ecs;
using UnityEngine;

namespace main
{

    public class EcsInit : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _systems;

        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;
        [SerializeField] private UI _ui;
        void Start()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            _systems
                .Add(new ButtonInitSystem())
                .Add(new LayoutInitSystem())
                .Add(new AddGameSystem())
                .Inject(_sceneData)
                .Inject(_staticData)
                .Inject(_ui)
                .Init();
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Run();
        }
    }
}
