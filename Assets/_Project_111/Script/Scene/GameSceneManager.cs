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
        _uiSceneGame.Init();
        
        Managers.Object.SpawnPlayer(_playerSpawnPoint.position);
        //Managers.Object.SpawnEnemy(_enemySpawnPoint.position);
    }


}
