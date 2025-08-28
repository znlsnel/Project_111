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


    #endregion

    protected abstract override void SetupController();

    protected abstract override void InitController();




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
