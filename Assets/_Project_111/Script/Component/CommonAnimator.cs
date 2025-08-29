using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class CommonAnimator : CreatureAnimator<CommonController>
{
    protected override int _moveHash { get; set; } = Animator.StringToHash("Move");
    protected override int _attackHash { get; set; } = Animator.StringToHash("Attack");
    protected override int _dieHash { get; set; } = Animator.StringToHash("Dead");


    

}
