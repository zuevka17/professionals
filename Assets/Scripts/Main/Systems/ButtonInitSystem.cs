using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace main
{
    public class ButtonInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private UI _ui = null;

        public void Init()
        {
            _ui.AddGameButton.onClick.AddListener(AddButtonLogic);
        }
        private void AddButtonLogic()
        {
            _ecsWorld.NewEntity().Get<AddGameEvent>();
            _ui.AddGameButton.transform.position += new Vector3(242.96f, 0f, 0f);
        }
    }
}
