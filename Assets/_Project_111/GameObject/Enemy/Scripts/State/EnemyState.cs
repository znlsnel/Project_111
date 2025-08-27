using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public abstract class EnemyState : CreatureState<EnemyController>
{

    public abstract override void Enter(object param);
    public abstract override void Exit();
    public abstract override void Tick(float deltaTime);
}
