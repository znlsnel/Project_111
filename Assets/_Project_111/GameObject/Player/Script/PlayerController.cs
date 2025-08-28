using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;


public class PlayerController : CreatureController
{

    #region << =========== FIELD =========== >>

    [SerializeField] private CharacterDataSO _playerData;

    #endregion

    #region << =========== PROPERTIES =========== >>

    public PlayerMovement Movement { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerStat Stat { get; private set; }

    public CharacterDataSO PlayerData => _playerData;

    #endregion

    protected override void SetupController()
    {
        Movement = this.GetOrAddComponent<PlayerMovement>();
        StateMachine = this.GetOrAddComponent<PlayerStateMachine>();
        Stat = this.GetOrAddComponent<PlayerStat>();

        StateMachine.Setup(this);
        Movement.Setup(this);
        Stat.Setup(this);
    }

    protected override void InitController()
    {
        StateMachine.Init(ECreatureStateType.Idle);
        Movement.Init();
        Stat.Init();
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
