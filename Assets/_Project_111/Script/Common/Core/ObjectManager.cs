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

    #region << =========== EFFECT =========== >>
    public GameObject CreateEffect(string effectName, Vector3 pos, float size = 1f)
    {
        var effect = base.Spawn(effectName, false);
        effect.transform.SetParent(null);
        effect.transform.position = pos;
        effect.transform.localScale *= size;
        return effect;
    }

    public GameObject CreateEffect(string effectName, Transform transform, float size = 1f)
    {
        var effect = base.Spawn(effectName, false);
        effect.transform.SetParent(transform);
        effect.transform.localPosition = Vector3.zero;
        effect.transform.localScale *= size;
        return effect;
    }

    #endregion
}
