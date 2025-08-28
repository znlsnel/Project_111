using UnityEngine;
using SongLib;


public class EnemyStat : CreatureStat<EnemyController>
{
    public override Stat MaxHPStat { get; protected set; }

    public override float MaxHP => MaxHPStat.FinalValue;

    protected override void ChangedHealthPoint(float fillAmount)
    {
        
    }

    protected override void InitMetrics()
    {
        CurrentHealth = MaxHP;
    }

    protected override void SetupStats()
    {
        MaxHPStat = new Stat(owner.MonsterData.MaxHP);
        CurrentHealth = MaxHP;
    }
}