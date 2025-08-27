using UnityEngine;
using SongLib;

public class PlayerMoveState : PlayerBaseState
{
    public override void Enter(object param)
    {
        DebugHelper.Log(EDebugType.State, "PlayerMoveState");
    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {
        if (owner.Movement.IsMoving)
            return;

        owner.StateMachine.ChangeState(owner.Target.IsDead ?
            ECreatureStateType.Idle : ECreatureStateType.Attack);
    }
}