using UnityEngine;

public class SkillDynamite : SkillBase
{
    protected override void OnSetup()
    {
        
    }

    protected override void OnShot()
    {
        Managers.Object.CreateDynamite(Owner, Owner.Target.transform.position);
    }
}