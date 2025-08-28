using UnityEngine;
using SongLib;
using System.Collections.Generic;

public class CommonCombat : CreatureCombat<CommonController>
{

    public override void Attack()
    {
        Managers.Object.CreateArrow(owner, owner.Target.transform.position);
    }

    public override void StopAttack()
    {

    }
    


}