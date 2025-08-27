using UnityEngine;
using SongLib;

public class PlayerDeadState : PlayerBaseState
{

    public override void Enter(object param)
    {
        DebugHelper.Log(EDebugType.State, "PlayerDeadState");
    }

    public override void Exit()
    {

    }



    public override void Tick(float deltaTime)
    {
        
    }
}