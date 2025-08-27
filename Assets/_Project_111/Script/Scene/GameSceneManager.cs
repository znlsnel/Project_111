using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class GameSceneManager : BaseSceneManager<GameSceneManager>
{
    [SerializeField] private UISceneGame _uiSceneGame;
    
    protected override void Init()
    {
        _uiSceneGame.Init();
    }


}
