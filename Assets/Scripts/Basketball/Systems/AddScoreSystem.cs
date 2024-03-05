using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class AddScoreSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<GoalEvent> _eventFilter;
        private EcsFilter<ScoreComponent> _scoreComponentFilter;
        public void Run()
        {
            foreach (var i in _eventFilter)
            {

                ref var score = ref _scoreComponentFilter.Get1(1);
                score.LevelScore++;
                score.GlobalScore++;

                Debug.Log($"Level Score: {score.LevelScore}, Global Score: {score.GlobalScore}");
            }
        }
    }
}
