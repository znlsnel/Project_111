using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;


public class GameManager : BaseGameManager
{
    protected override void AddManagers()
    {
        _managers.Add(ResourceManager.Instance);
        _managers.Add(ObjectManager.Instance);
        _managers.Add(AudioManager.Instance);
        _managers.Add(UIManager.Instance);
        _managers.Add(ObjectPoolManager.Instance);
        _managers.Add(PopupManager.Instance);
        _managers.Add(SceneFlowManager.Instance);
        _managers.Add(EventManager.Instance);
    }

    protected override void InitializeManagerForce()
    {
        
    }

    protected override void OnInit()
    {
        
    }
}
