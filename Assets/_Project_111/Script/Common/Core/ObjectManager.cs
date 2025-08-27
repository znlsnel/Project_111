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


    public void SpawnPlayer(Vector3 spawnPosition)
    {
        GameObject go = base.Spawn(StringKey.Player, true);
        go.transform.position = spawnPosition;
        go.GetComponent<PlayerController>().Init();
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject go = base.Spawn(StringKey.Enemy, true);
        go.transform.position = spawnPosition;
        go.GetComponent<EnemyController>().Init();
    }


}
