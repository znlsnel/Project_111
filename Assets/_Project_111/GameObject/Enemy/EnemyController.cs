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

    public MonsterMovement Movement { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    public CharacterDataSO MonsterData => _monsterData;

    #endregion

    protected override void SetupController()
    {
        Movement = this.GetOrAddComponent<MonsterMovement>();
        StateMachine = this.GetOrAddComponent<EnemyStateMachine>();
    }

    protected override void InitController()
    {
        StateMachine.Setup(this);
        Movement.Setup(this);

      //  StateMachine.Init(ECreatureStateType.Idle);
     //   Movement.Init();
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
        
    }


}
