using UnityEngine;
using System.Collections.Generic;

public class SkillAirBrake : SkillBase
{
    [SerializeField] private float _slowPercent;
    [SerializeField] private float _slowDuration;

    protected override void OnSetup()
    {

    }
    protected override void OnShot()
    {
        List<ProjectileController> projectiles = Managers.Object.GetProjectiles(Owner.Target);
        foreach (ProjectileController pc in projectiles)
        {
            pc.OnSlow(_slowPercent, _slowDuration);
        }
    }

}