using UnityEngine;
using SongLib;

public class PlayerDeadState : PlayerBaseState
{

    public override void Enter(object param)
    {
        owner.Animator.DieTrue();
    }   

    public override void Exit()
    {
        owner.Animator.DieFalse();
    }   



    public override void Tick(float deltaTime)
    {
        
    }
}