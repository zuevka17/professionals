using Leopotam.Ecs;
using UnityEngine;

namespace basketball 
{
    public class EcsInit : MonoBehaviour
    {
        public EcsWorld World;
        private EcsSystems _ecsSystems;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;

        void Start()        
        {
            World  = new EcsWorld();
            _ecsSystems = new EcsSystems(World);

            _ecsSystems
                .Add(new Parser())
                .Add(new StartGameSystem())
                .Add(new BallInitSystem())
                .Add(new CalculateSwipeSpeed())
                .Add(new AddMovementToBall())
                .Add(new AddScoreSystem())
                .Add(new LevelPassSystem())
                .Add(new LoadLevel())
                .Add(new OnTouchFloorSystem())
                .Add(new BallDestroySystem())
                .Add(new BallToNextPosSystem())
                .Inject(_sceneData)
                .Inject(_staticData)
                .Init();       
        }

        void Update()
        {
            _ecsSystems.Run();
        }
    }
}
