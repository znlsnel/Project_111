using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyMoveState : EnemyState
{

    public override void Enter(object param)
    {
        owner.Animator.StartMove();

    }

    public override void Exit()
    {
        owner.Animator.StopMove();
    }

    public override void Tick(float deltaTime)
    {
        if (owner.Movement.IsMoving)
            return;

        owner.StateMachine.ChangeState(owner.Target.IsDead ?
            ECreatureStateType.Idle : ECreatureStateType.Attack);
    
    }
}
