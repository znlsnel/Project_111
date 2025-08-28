using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class GameSceneManager : BaseSceneManager<GameSceneManager>
{
    [SerializeField] private UISceneGame _uiSceneGame;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;


    protected override void Init()
    {
        SetObject();
        _uiSceneGame.Init();
    }

    private void SetObject()
    {
        Managers.Object.SpawnPlayer(_playerSpawnPoint.position);
        Managers.Object.SpawnEnemy(_enemySpawnPoint.position);

        Managers.Object.Player.SetTarget(Managers.Object.Enemy);
        Managers.Object.Enemy.SetTarget(Managers.Object.Player);
    }


}
