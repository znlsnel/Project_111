using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;
using System;
using DG.Tweening;

public class GameSceneManager : BaseSceneManager<GameSceneManager>
{
    [SerializeField] private UISceneGame _uiSceneGame;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private Rect _enemyMoveArea;
    [SerializeField] private CameraEffect _cameraEffect;

    private int _gameTime = 60;
    private GameTimer _gameTimer;
    private bool _isGameOver = false;

    public Rect EnemyMoveArea => _enemyMoveArea;
    public CameraEffect CameraEffect => _cameraEffect;

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_enemyMoveArea.center, _enemyMoveArea.size);
    }
#endif

    protected override void Init()
    {
  
        _cameraEffect.Init();
        _gameTimer = new GameObject("GameTimer").AddComponent<GameTimer>();
        Time.timeScale = 1f;
        _uiSceneGame.SetActive(false);

        UIPopupStartGame popup = Global.Popup.OpenPopup(EPopupType.StartGame) as UIPopupStartGame;
        popup.Refresh();
    }

    public void StartGame()
    {
        _uiSceneGame.SetActive(true);
        _isGameOver = false;

        SetObject();
        _uiSceneGame.Init();

        _gameTimer.SetTimer(OnTimeChanged, _gameTime);

        _cameraEffect.SetDefaultMode();
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
        if (_isGameOver)
            return;

        _isGameOver = true;

        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0f, 3f)
            .SetEase(Ease.OutQuad)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                Time.timeScale = 0f;
            });

        float playerHp = Managers.Object.Player.Stat.CurrentHealth;
        float enemyHp = Managers.Object.Enemy.Stat.CurrentHealth;

        UIPopupGameOver popup = Global.Popup.OpenPopup(EPopupType.GameOver) as UIPopupGameOver;
        popup.SetResult(playerHp > enemyHp);
    }

}
