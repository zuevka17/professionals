using Leopotam.Ecs;
using UnityEngine;

public class StartGameSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    public void Run()
    {
        ref var music = ref _world.NewEntity().Get<AudioComponent>();
        var sources = Camera.main.GetComponents<AudioSource>();
        music.musicSource = sources[0];
        music.audioSource = sources[1];

        _world.NewEntity().Get<TimerComponent>().isGoing = true;
    }
}
