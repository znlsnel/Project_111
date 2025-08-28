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
        if (Data == null)
        {
            DebugHelper.LogError(EDebugType.Combat, "Data is null");
            return;
        }

        
        Movement = this.GetOrAddComponent<PlayerMovement>();
        StateMachine = this.GetOrAddComponent<PlayerStateMachine>();
        Stat = this.GetOrAddComponent<CommonStat>();
        Combat = this.GetOrAddComponent<CommonCombat>();
        Skill = this.GetOrAddComponent<CommonSkill>();

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
    }


}
