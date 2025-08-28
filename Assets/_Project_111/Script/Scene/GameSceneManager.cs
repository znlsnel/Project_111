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
    private GameTimer _gameTimer;

    protected override void Init()
    {
        _gameTimer = new GameObject("GameTimer").AddComponent<GameTimer>();
        Time.timeScale = 1f;
        _uiSceneGame.SetActive(false);

        UIPopupStartGame popup = Global.Popup.OpenPopup(EPopupType.StartGame) as UIPopupStartGame;
        popup.Refresh();
    }

    public void StartGame()
    {
        _uiSceneGame.SetActive(true);

        SetObject();
        _uiSceneGame.Init();

        _gameTimer.SetTimer(OnTimeChanged, _gameTime);
    }

    private void SetObject()
    {
        Managers.Object.SpawnPlayer(_playerSpawnPoint.position);
        Managers.Object.SpawnEnemy(_enemySpawnPoint.position);

        Managers.Object.Player.SetTarget(Managers.Object.Enemy);
        Managers.Object.Enemy.SetTarget(Managers.Object.Player);

        Managers.Object.Player.OnDead += OnGameOver;
        Managers.Object.Enemy.OnDead += OnGameOver;
    }

    private void OnTimeChanged(int time)
    {
        int leftTime = _gameTime - time;
        _uiSceneGame.Top.Timer.SetTime(leftTime);

        if (leftTime == 0)
        {
            OnGameOver();
        }
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        bool isPlayerDead = Managers.Object.Player.Stat.CurrentHealth <= 0;
        bool isEnemyDead = Managers.Object.Enemy.Stat.CurrentHealth <= 0;

        UIPopupGameOver popup = Global.Popup.OpenPopup(EPopupType.GameOver) as UIPopupGameOver;

        if (!isPlayerDead && isEnemyDead)
            popup.SetResult(1);
        else if (isPlayerDead && !isEnemyDead)
            popup.SetResult(0);
        else
            popup.SetResult(2);
    }

}
