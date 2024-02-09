using Leopotam.Ecs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class WinSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private StaticData _sceneData = null;
    private UI _ui = null;
    private EcsFilter<WinEvent> _filter = null;
    private EcsFilter<TimerComponent> _filterForTimer = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var winEvent = ref _filter.Get1(1);
            _ui.gameScreenScreenSpace.coinsLable.text = $"{Convert.ToInt32(_ui.gameScreenScreenSpace.coinsLable.text) + _sceneData.rewardForLevel}";
            _filter.GetEntity(i).Destroy();
            Debug.Log("winEvent happens");

            _filterForTimer.GetEntity(0).Get<TimerComponent>().isGoing = false;
        }
        
    }
}
