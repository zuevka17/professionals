using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace main
{
    public class LayoutInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private StaticData _staticData = null;
        private SceneData _sceneData = null;
        public void Init()
        {
            var gameObject = Object.Instantiate(_staticData.LayoutPrefab, _sceneData.LayoutSpawnPoint.transform.position, Quaternion.identity, _sceneData.LayoutSpawnPoint.transform);

            EcsEntity layoutEntity = _ecsWorld.NewEntity();

            ref var layoutCompnoent = ref layoutEntity.Get<LayoutComponent>();

            layoutCompnoent.GO = gameObject;
            layoutCompnoent.LayoutGroup = gameObject.GetComponent<HorizontalLayoutGroup>();
        }
    }
}
