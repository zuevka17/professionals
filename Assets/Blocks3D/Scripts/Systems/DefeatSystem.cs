using Leopotam.Ecs;
using UnityEngine;

public class DefeatSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private UI _ui = null;
    private SceneData _sceneData = null;
    private EcsFilter<DefeatEvent> _filter = null;
    public void Run()
    {
        foreach (var i in _filter)
        {
            _ui.gameScreenScreenSpace.playButton.image.sprite = Resources.Load<Sprite>("Sprites/replay");
            _ui.gameScreenScreenSpace.playButton.gameObject.SetActive(true);

            Debug.Log("DefeatEvent hapens!");
            _filter.GetEntity(i).Destroy();

            CenterCheckSystem.count = 0;

            StopCubeMovement();
            DisableButtons();
        }
    }
    private void StopCubeMovement()
    {
        _sceneData.isLeftCubesMoves = false;
        _sceneData.isRightCubesMoves = false;
        _sceneData.isUpCubesMoves = false;
        _sceneData.isDownCubesMoves = false;
    }
    private void DisableButtons()
    {
        _ui.gameScreenWorldSpace.gameObject.SetActive(false);
    }
}
