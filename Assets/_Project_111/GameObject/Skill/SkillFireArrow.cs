using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFireArrow : SkillBase
{
    protected override void OnSetup()
    {
        
    }

    protected override void OnShot()
    {
        Managers.Object.CreateFireArrow(Owner, Owner.Target.transform.position);
    }
}
