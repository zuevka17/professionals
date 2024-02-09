using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInitSystem : IEcsInitSystem
{
    private EcsWorld _world = null;
    private SceneData _sceneData = null;    
    private UI _ui = null;
    private EcsFilter<AudioComponent> _audioFilter = null;
    public void Init()
    {
        //Listener для всех кнопок
        AddListenerForEveryButton();
        //WorldSpace
        _ui.gameScreenWorldSpace.leftButton.onClick.AddListener(delegate { MoveCubesByClick("left"); });
        _ui.gameScreenWorldSpace.rightButton.onClick.AddListener(delegate { MoveCubesByClick("right"); });
        _ui.gameScreenWorldSpace.upButton.onClick.AddListener(delegate { MoveCubesByClick("up"); });
        _ui.gameScreenWorldSpace.downButton.onClick.AddListener(delegate { MoveCubesByClick("down"); });
        //ScreenSpace
        _ui.gameScreenScreenSpace.musicButton.onClick.AddListener(ChangeMusicState);
    }
    void MoveCubesByClick(string whichSide)
    {
        switch(whichSide)
        {
            case "left":
                _sceneData.isLeftCubesMoves = true;
                break;
            case "right":
                _sceneData.isRightCubesMoves = true;
                break;
            case "up":
                _sceneData.isUpCubesMoves = true;
                break;
            case "down":
                _sceneData.isDownCubesMoves = true;
                break;
        }
    }
    void AddListenerForEveryButton()
    {
        Button[] buttons = GameObject.FindObjectsOfType<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(PlayAudioOnClick);
        }
    }
    void PlayAudioOnClick()
    {
        foreach(var i in _audioFilter)
        {
            ref var audio = ref _audioFilter.Get1(i);
            audio.audioSource.Play();
        }    
    }
    void ChangeMusicState()
    {
        foreach(var i in _audioFilter)
        {
            ref var audio = ref _audioFilter.Get1(i);
            audio.musicSource.mute = !audio.musicSource.mute;
        }
    }
}
