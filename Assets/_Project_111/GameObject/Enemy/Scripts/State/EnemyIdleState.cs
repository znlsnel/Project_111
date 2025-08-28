using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyIdleState  : EnemyState
{

    public override void Enter(object param)
    {
        

    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        if (!owner.Movement.IsMoving && !owner.Target.IsDead)
            owner.StateMachine.ChangeState(ECreatureStateType.Attack);

        else if (owner.Movement.IsMoving)
            owner.StateMachine.ChangeState(ECreatureStateType.Move);
    }
}
