using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyAttackState : EnemyState
{
    private float _lastAttackTime = 0f;
    public override void Enter(object param)
    {
        owner.StartCoroutine(MoveToRandomPosition(Random.Range(1f, 3f)));
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


        else if (Time.time - _lastAttackTime > owner.Data.AttackDelay)
        {
            owner.Animator.TriggerAttack();
            _lastAttackTime = Time.time;
        }
    }

    private IEnumerator MoveToRandomPosition(float nextMoveTime)
    {
        yield return new WaitForSeconds(nextMoveTime);

        float nextXPos = 0f;
        do
        {
            nextXPos = Random.Range(GameSceneManager.Instance.EnemyMoveArea.xMin, GameSceneManager.Instance.EnemyMoveArea.xMax);
        } while (Mathf.Abs(nextXPos - owner.transform.position.x) < 1f);

        owner.Movement.MoveToPosition(new Vector3(nextXPos, owner.transform.position.y, owner.transform.position.z));
    }
}
