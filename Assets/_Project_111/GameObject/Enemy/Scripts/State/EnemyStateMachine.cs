using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyStateMachine : CreatureStateMachine<EnemyController>
{
    protected override void CreateStates()
    {
        states = new Dictionary<ECreatureStateType, IState>
        {
            { ECreatureStateType.Idle, new EnemyIdleState() },
            { ECreatureStateType.Move, new EnemyMoveState() },
            { ECreatureStateType.Attack, new EnemyAttackState() },
            { ECreatureStateType.Dead, new EnemyDeadState() },
        };
    }
}
