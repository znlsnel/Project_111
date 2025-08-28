using UnityEngine;
using SongLib;


public class CommonStat : CreatureStat<CommonController>
{
    public override Stat MaxHPStat { get; protected set; }

    public override float MaxHP => MaxHPStat.FinalValue;


    protected override void SetupStats()
    {
        MaxHPStat = new Stat(owner.Data.MaxHP);
        CurrentHealth = MaxHP;
    }

    protected override void InitMetrics()
    {
        CurrentHealth = MaxHP;
    }
    
    protected override void ChangedHealthPoint(float fillAmount)
    {
        
    }


}