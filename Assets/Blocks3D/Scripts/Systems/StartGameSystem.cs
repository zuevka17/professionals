using Leopotam.Ecs;
using UnityEngine;

public class StartGameSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsWorld _world = null;
    private UI _ui = null;
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
        _world.NewEntity().Get<CubeInitTrigger>();
        _world.NewEntity().Get<NextLevelEvent>();
        EnableButtons();
    }
    private void EnableButtons()
    {
        _ui.gameScreenWorldSpace.gameObject.SetActive(true);
    }
}
