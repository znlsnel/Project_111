using UnityEngine;
using SongLib;

public class PlayerIdleState : PlayerBaseState
{

    public override void Enter(object param)
    {
        DebugHelper.Log(EDebugType.State, "PlayerIdleState");
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