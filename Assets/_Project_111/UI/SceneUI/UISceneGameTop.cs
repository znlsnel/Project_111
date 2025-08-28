using System.Collections;
using System.Collections.Generic;
using SongLib;
using UnityEngine;

public class UISceneGameTop : UIPanel
{
    [SerializeField] private UIHealthBar _playerHpBar;
    [SerializeField] private UIHealthBar _enemyHpBar;

    public UIHealthBar PlayerHpBar => _playerHpBar;
    public UIHealthBar EnemyHpBar => _enemyHpBar;

    protected override void OnInit()
    {
        _playerHpBar.Setup(Managers.Object.Player.Stat);
        _enemyHpBar.Setup(Managers.Object.Enemy.Stat);
    }

    protected override void OnRefresh()
    {
        
    }
}
