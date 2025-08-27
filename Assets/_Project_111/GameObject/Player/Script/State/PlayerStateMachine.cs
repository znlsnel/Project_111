using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class PlayerStateMachine : CreatureStateMachine<PlayerController>
{
    protected override void CreateStates()
    {
        states = new Dictionary<ECreatureStateType, IState>
        {
            { ECreatureStateType.Idle, new PlayerIdleState() },
            { ECreatureStateType.Move, new PlayerMoveState() },
            { ECreatureStateType.Attack, new PlayerAttackState() },
            { ECreatureStateType.Dead, new PlayerDeadState() },
        };
    }


}
