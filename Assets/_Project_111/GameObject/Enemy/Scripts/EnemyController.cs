using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyController : CommonController
{
    private Coroutine _coLaunchSkill;
    #region << =========== PROPERTIES =========== >>
    public EnemyMovement Movement { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    #endregion

    protected override void SetupController()
    {
        base.SetupController();

        Movement = this.GetOrAddComponent<EnemyMovement>();
        StateMachine = this.GetOrAddComponent<EnemyStateMachine>();

        StateMachine.Setup(this);
        Movement.Setup(this);
    }

    protected override void InitController()
    {
        base.InitController();

        StateMachine.Init(ECreatureStateType.Idle);
        Movement.Init();

        if (_coLaunchSkill != null)
            StopCoroutine(_coLaunchSkill);
        _coLaunchSkill = StartCoroutine(LaunchSkill());
    }

    private IEnumerator LaunchSkill()
    {
        while (true)
        {
            if ((Target != null && Target.IsDead) || IsDead)
                break;

            yield return new WaitForSeconds(Random.Range(3f, 5f));

            List<SkillBase> useableSkills = Skill.Skills.FindAll(s => s.IsUseable);
            if (useableSkills.Count > 0)
            {
                SkillBase skill = useableSkills[Random.Range(0, useableSkills.Count)];
                skill.ShotSkill();
            }
        }

        _coLaunchSkill = null;
    }

}
