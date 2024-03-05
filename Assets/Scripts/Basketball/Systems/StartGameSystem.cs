using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class StartGameSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private SceneData _sceneData = null;
        private StaticData _staticData = null;

        public void Init()
        {
            _ecsWorld.NewEntity().Get<BasketComponent>().BasketAnimator = GameObject.Find("Basket").GetComponent<Animator>();

            var score = _ecsWorld.NewEntity();
            ref var scoreComponent = ref score.Get<ScoreComponent>();
            scoreComponent.LevelScore = 0;
            scoreComponent.GlobalScore = 0;
        }
    }
}