using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace basketball
{
    public class AddMovementToBall : IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<BallComponent> _ballFilter = null;
        private EcsFilter<SwipeComponent> _swipeFilter = null;
        private EcsFilter<AddForceEvent> _eventFilter = null;
        public void Run()
        {
            foreach (var i in _eventFilter)
            {
                ref var swipe = ref _swipeFilter.Get1(1);

                ref var ball = ref _ballFilter.Get1(1);
                
                ball.BallRigidbody.AddForce(new Vector3(-ball.BallTransform.position.x, 
                    -ball.BallTransform.position.y * swipe.FinalSpeed * 100,
                    -ball.BallTransform.position.z * swipe.FinalSpeed), 
                    ForceMode.Impulse);
                
                ball.BallRigidbody.useGravity = true;

                _eventFilter.GetEntity(i).Destroy();
            }
        }
    }
}
