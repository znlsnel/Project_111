using UnityEngine;
using SongLib;

public class PlayerAttackState : PlayerBaseState
{
    private float _lastAttackTime;

    public override void Enter(object param)
    {

    }

    public override void Exit()
    {

    }


    public override void Tick(float deltaTime)
    {
        if (owner.Movement.IsMoving)
            owner.StateMachine.ChangeState(ECreatureStateType.Move);

        else if (owner.Target.IsDead)
            owner.StateMachine.ChangeState(ECreatureStateType.Idle);


        else if (Time.time - _lastAttackTime > playerData.AttackDelay)
        {
            owner.Animator.TriggerAttack();
            _lastAttackTime = Time.time;
        }
    }

}