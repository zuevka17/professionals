using Leopotam.Ecs;
using UnityEngine;

namespace basketball 
{
    public class EcsInit : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _ecsSystems;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;

        void Start()        
        {
            _ecsWorld  = new EcsWorld();
            _ecsSystems = new EcsSystems(_ecsWorld);

            _ecsSystems
                .Add(new BallInitSystem())
                .Add(new CalculateSwipeSpeed())
                .Add(new AddMovementToBall())
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
