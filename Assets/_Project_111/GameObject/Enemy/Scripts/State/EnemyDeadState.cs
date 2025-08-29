using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyDeadState  : EnemyState
{

    public override void Enter(object param)
    {
        owner.Animator.DieTrue();

    }

    public override void Exit()
    {
        owner.Animator.DieFalse();
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
