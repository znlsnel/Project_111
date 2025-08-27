using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class PlayerStateMachine : CreatureStateMachine<PlayerController>
{
    protected override void CreateStates()
    {
        states = new Dictionary<CreatureStateType, IState>
        {
            { CreatureStateType.Idle, new PlayerIdleState() },
            { CreatureStateType.Move, new PlayerMoveState() },
        };
    }


}
