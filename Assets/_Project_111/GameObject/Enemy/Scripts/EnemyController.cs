using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyController : CommonController
{
    #region << =========== PROPERTIES =========== >>
    public EnemyMovement Movement { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    #endregion

    protected override void SetupController()
    {
        Movement = this.GetOrAddComponent<EnemyMovement>();
        StateMachine = this.GetOrAddComponent<EnemyStateMachine>();
        Stat = this.GetOrAddComponent<CommonStat>();
        Skill = this.GetOrAddComponent<CommonSkill>();
        Combat = this.GetOrAddComponent<CommonCombat>();

        StateMachine.Setup(this);
        Movement.Setup(this);
        Stat.Setup(this);
        Combat.Setup(this);
        Skill.Setup(this);
    }

    protected override void InitController()
    {
        StateMachine.Init(ECreatureStateType.Idle);
        Movement.Init();
        Stat.Init();
        Skill.Init();
        Combat.Init();

        StartCoroutine(LaunchSkill());
    }

    private IEnumerator LaunchSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f));

            List<SkillBase> useableSkills = Skill.Skills.FindAll(s => s.IsUseable);
            if (useableSkills.Count > 0 && !Target.IsDead)
            {
                SkillBase skill = useableSkills[Random.Range(0, useableSkills.Count)];
                skill.ShotSkill();
            }
        }
    }

}
