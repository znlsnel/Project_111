using UnityEngine;
using SongLib;


public class PlayerStat : CreatureStat<PlayerController>
{
    public override Stat MaxHPStat { get; protected set; }

    public override float MaxHP => MaxHPStat.FinalValue;


    protected override void SetupStats()
    {
        MaxHPStat = new Stat(owner.PlayerData.MaxHP);
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