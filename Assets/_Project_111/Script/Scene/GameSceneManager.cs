using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;
using System;

public class GameSceneManager : BaseSceneManager<GameSceneManager>
{
    [SerializeField] private UISceneGame _uiSceneGame;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;


    private int _gameTime = 60;


    protected override void Init()
    {
        SetObject();
        _uiSceneGame.Init();

        GameTimer.Instance.SetTimer(OnTimeChanged, _gameTime);
    }

    private void SetObject()
    {
        Managers.Object.SpawnPlayer(_playerSpawnPoint.position);
        Managers.Object.SpawnEnemy(_enemySpawnPoint.position);

        Managers.Object.Player.SetTarget(Managers.Object.Enemy);
        Managers.Object.Enemy.SetTarget(Managers.Object.Player);
    }

    private void OnTimeChanged(int time)
    {
        int leftTime = _gameTime - time;
        _uiSceneGame.Top.Timer.SetTime(leftTime);
    }

}
