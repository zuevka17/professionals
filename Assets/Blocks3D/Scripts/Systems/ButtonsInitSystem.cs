using Leopotam.Ecs;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInitSystem : IEcsInitSystem
{
    private EcsWorld _world = null;
    private SceneData _sceneData = null;
    private StaticData _staticData = null;
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
        _ui.gameScreenScreenSpace.audioButon.onClick.AddListener(ChangeAudioState);
        _ui.gameScreenScreenSpace.musicButton.onClick.AddListener(ChangeMusicState);
        _ui.gameScreenScreenSpace.dailyRewardButton.onClick.AddListener(AddCoins);
    }
    //Разрешаем кубам определенной стороны двигаться
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
    //Listener для всех кнопок
    void AddListenerForEveryButton()
    {
        Button[] buttons = GameObject.FindObjectsOfType<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(PlayAudioOnClick);
        }
    }
    //Звук нажатия кнопки
    void PlayAudioOnClick()
    {
        foreach(var i in _audioFilter)
        {
            ref var audio = ref _audioFilter.Get1(i);
            audio.audioSource.Play();
        }    
    }
    //Вкл/выкл звука/музыки.
    void ChangeMusicState()
    {
        foreach(var i in _audioFilter)
        {
            ref var audio = ref _audioFilter.Get1(i);
            audio.musicSource.mute = !audio.musicSource.mute;
        }
    }
    void ChangeAudioState()
    {
        foreach(var i in _audioFilter)
        {
            ref var audio = ref _audioFilter.Get1(i);
            audio.audioSource.mute = !audio.audioSource.mute;
        }
    }
    void AddCoins()
    {
        _ui.gameScreenScreenSpace.coinsLable.text = $"{Convert.ToInt32(_ui.gameScreenScreenSpace.coinsLable.text) + _staticData.dailyRewardAmount}"; 
    }
}
