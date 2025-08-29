using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;


public abstract class CommonController : CreatureController
{

    #region << =========== FIELD =========== >>

    [SerializeField] protected CharacterDataSO data;

    #endregion

    #region << =========== PROPERTIES =========== >>

    public CharacterDataSO Data => data;
    public CommonStat Stat { get; protected set; }
    public CommonCombat Combat { get; protected set; }
    public CommonSkill Skill { get; protected set; }
    public CommonAnimator Animator { get; protected set; }
    public CommonAnimationEvent AnimationEvent { get; protected set; }


    #endregion

    protected override void SetupController()
    {
        AnimationEvent = GetComponentInChildren<CommonAnimationEvent>();
        Animator = GetComponentInChildren<CommonAnimator>();
        Stat = this.GetOrAddComponent<CommonStat>();
        Combat = this.GetOrAddComponent<CommonCombat>();
        Skill = this.GetOrAddComponent<CommonSkill>();

        AnimationEvent.Setup(this);
        Animator.Setup(this);
        Stat.Setup(this);
        Combat.Setup(this);
        Skill.Setup(this);
    }

    protected override void InitController()
    {
        AnimationEvent.Init();
        Animator.Init();
        Stat.Init();
        Combat.Init();
        Skill.Init();
    }




    public override void Dead()
    {
        base.Dead();
        DebugHelper.Log(EDebugType.Combat, "Player Dead");
    }

    public override void Despawn()
    {

    }


    public override void KnockBack(float knockbackPower)
    {

    }

    public override void TakeDamage(float amount, DamageType type)
    {
        if (Stat.CurrentHealth <= 0f)
            return;

        Stat.CurrentHealth -= amount;
    }




}
