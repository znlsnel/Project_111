using UnityEngine;
using SongLib;

public class CommonAnimationEvent : CreatureAnimationEvent<CommonController>
{

    public override void OnStartAttack()
    {
        
    }

    public override void OnHitAttack()
    {
        owner.Combat.Attack();
    }

    public override void OnEndAttack()
    {
        
    }

    public override void OnStartSkill()
    {
        
    }

    public override void OnExecuteSkill(int id)
    {
        
    }

    public override void OnHitSkill()
    {
        
    }

    public override void OnEndSkill()
    {
        
    }
}