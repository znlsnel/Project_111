using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;


public class PlayerController : CommonController
{

    #region << =========== PROPERTIES =========== >>

    public PlayerMovement Movement { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    #endregion

    protected override void SetupController()
    {
        base.SetupController();

        Movement = this.GetOrAddComponent<PlayerMovement>();
        StateMachine = this.GetOrAddComponent<PlayerStateMachine>();


        StateMachine.Setup(this);
        Movement.Setup(this);
    }

    protected override void InitController()
    {
        base.InitController();

        StateMachine.Init(ECreatureStateType.Idle);
        Movement.Init();
    }
    

    public override void TakeDamage(float amount, DamageType type)
    {
        base.TakeDamage(amount, type);
        GameSceneManager.Instance.CameraEffect.ZoomEffect();
    }


}
