using Leopotam.Ecs;
using UnityEngine;


namespace basketball 
{
    public class BallInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private SceneData _sceneData = null;
        private StaticData _staticData = null;

        public void Init()
        {
            var GO = Object.Instantiate(_staticData.BallPrefab,
                _sceneData.SpawnPoint.transform.position, 
                Quaternion.identity);

            EcsEntity ballEntity = _ecsWorld.NewEntity();
            ref var ballComponent = ref ballEntity.Get<BallComponent>();

            ballComponent.GO = GO;
            ballComponent.BallTransform = GO.GetComponent<Transform>();
            ballComponent.BallRigidbody = GO.GetComponent<Rigidbody>();
        }
    }
}
