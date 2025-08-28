using System.Collections;
using System.Collections.Generic;
using SongLib;
using UnityEngine;

public class UISceneGameTop : UIPanel
{
    [SerializeField] private UIHealthBar _playerHpBar;
    [SerializeField] private UIHealthBar _enemyHpBar;
    [SerializeField] private UITimer _timer;

    public UIHealthBar PlayerHpBar => _playerHpBar;
    public UIHealthBar EnemyHpBar => _enemyHpBar;
    public UITimer Timer => _timer;

    protected override void OnInit()
    {
        _playerHpBar.Setup(Managers.Object.Player.Stat);
        _enemyHpBar.Setup(Managers.Object.Enemy.Stat);

    }

    protected override void OnRefresh()
    {
        
    }
}
