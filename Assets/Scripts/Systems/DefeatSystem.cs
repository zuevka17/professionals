using Leopotam.Ecs;
using UnityEngine;

public class DefeatSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private UI _ui;
    private EcsFilter<DefeatEvent> _filter = null;
    public void Run()
    {
        foreach(var i in _filter)
        {
            _ui.gameScreenScreenSpace.playButton.image.sprite = Resources.Load<Sprite>("replay");
            _ui.gameScreenScreenSpace.playButton.gameObject.SetActive(true);
            
            Debug.Log("DefeatEvent hapens!");
            _filter.GetEntity(i).Destroy();
        }
    }
}
