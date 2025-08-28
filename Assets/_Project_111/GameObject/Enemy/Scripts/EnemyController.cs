using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyController : CreatureController
{

    #region << =========== FIELD =========== >>

    [SerializeField] private CharacterDataSO _monsterData;

    #endregion

    #region << =========== PROPERTIES =========== >>


    public EnemyMovement Movement { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyStat Stat { get; private set; }

    public CharacterDataSO MonsterData => _monsterData;

    #endregion

    protected override void SetupController()
    {
        Movement = this.GetOrAddComponent<EnemyMovement>();
        StateMachine = this.GetOrAddComponent<EnemyStateMachine>();
        Stat = this.GetOrAddComponent<EnemyStat>();

        // StateMachine.Setup(this);
        // Movement.Setup(this);
        Stat.Setup(this);
    }

    protected override void InitController()
    {

      //  StateMachine.Init(ECreatureStateType.Idle);
     //   Movement.Init();
        Stat.Init();
    }    



    public override void Dead()
    {

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
