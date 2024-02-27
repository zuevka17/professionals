using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace main
{
    public class AddGameSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private StaticData _staticData = null;
        private UI _ui = null;

        private EcsFilter<AddGameEvent> _eventFilter = null; 
        private EcsFilter<LayoutComponent> _layoutFilter = null;

        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                ref var layout = ref _layoutFilter.Get1(1);
                var gameObject = Object.Instantiate(_staticData.GamePrefab, layout.GO.transform.position, Quaternion.identity, layout.GO.transform);

                EcsEntity gameEntity = _ecsWorld.NewEntity();

                ref var gameComponent = ref gameEntity.Get<GameComponent>();

                gameComponent.GO = gameObject;
                gameComponent.GameImage = gameObject.GetComponentInChildren<Image>();
                gameComponent.GameName = gameObject.GetComponentInChildren<TMP_Text>();

                gameComponent.GameName.text = "test";

                _eventFilter.GetEntity(i).Destroy();
            }
        }
    }
}