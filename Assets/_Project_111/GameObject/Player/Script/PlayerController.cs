using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;


public class PlayerController : CreatureController
{
    #region << =========== PROPERTIES =========== >>

    public PlayerMovement Movement { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    #endregion

    protected override void SetupController()
    {
        Movement = this.GetOrAddComponent<PlayerMovement>();
        StateMachine = this.GetOrAddComponent<PlayerStateMachine>();
    }

    protected override void InitController()
    {
        StateMachine.Setup(this);
        Movement.Setup(this);

        StateMachine.Init(CreatureStateType.Idle);
        Movement.Init();
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
