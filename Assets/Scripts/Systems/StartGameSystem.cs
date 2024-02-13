using Leopotam.Ecs;
using UnityEngine;

public class StartGameSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsWorld _world = null;
    private UI _ui = null;
    private EcsFilter<TimerComponent> _timerFilter = null;
    public void Init()
    {
        ref var music = ref _world.NewEntity().Get<AudioComponent>();
        var sources = Camera.main.GetComponents<AudioSource>();
        music.musicSource = sources[0];
        music.audioSource = sources[1];

        _world.NewEntity().Get<TimerComponent>().isGoing = false;
    }
    public void Run()
    {
        foreach (var i in _timerFilter)
        {
            ref var timer = ref _timerFilter.Get1(i);
            timer.timerImage.fillAmount = 1f;
            timer.isGoing = true;
        }
        EnableButtons();

    }
    private void EnableButtons()
    {
        _ui.gameScreenWorldSpace.gameObject.SetActive(true);
    }
}
