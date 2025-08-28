using UnityEngine;
using SongLib;

public class PlayerAttackState : PlayerBaseState
{
    private float _lastAttackTime;

    public override void Enter(object param)
    {
        DebugHelper.Log(EDebugType.State, "PlayerAttackState");


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


        if (Time.time - _lastAttackTime > playerData.AttackDelay)
        {
            OnAttack();
            _lastAttackTime = Time.time;
        }
    }


    private void OnAttack()
    {
        GameObject arrow = Global.Object.Spawn(StringKey.Arrow, true);

        arrow.transform.position = owner.transform.position;
        var pc = arrow.GetComponent<ProjectileController>();
        pc.Setup(owner.Target);
        pc.Shot(owner.Target.transform.position);
    }
}