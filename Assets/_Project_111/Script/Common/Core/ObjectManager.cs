using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using SongLib;

public class ObjectManager : BaseObjectManager<ObjectManager>
{
    protected override void Reset()
    {

    }

    #region << =========== PLAYER =========== >>
    private PlayerController _player;
    public PlayerController Player => _player;
    
    public void SpawnPlayer(Vector3 spawnPosition)
    {
        GameObject go = base.Spawn(StringKey.Player, false);
        go.transform.position = spawnPosition;
        go.GetComponent<PlayerController>().Init();
        _player = go.GetComponent<PlayerController>();
    }

    #endregion


    #region << =========== ENEMY =========== >>
    public EnemyController _enemy;
    public EnemyController Enemy => _enemy;
    public void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject go = base.Spawn(StringKey.Enemy, false);
        go.transform.position = spawnPosition;
        go.GetComponent<EnemyController>().Init();
        _enemy = go.GetComponent<EnemyController>();
    }

    #endregion
}
