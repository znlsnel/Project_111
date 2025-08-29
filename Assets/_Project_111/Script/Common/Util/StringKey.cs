using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringKey
{
    public const string Player = "Player";
    public const string Enemy = "Enemy";
    public const string Arrow = "Arrow";
    public const string Dynamite = "Arrow_Dynamite";
    public const string DamageUI = "UIWorldDamage";



    private static Dictionary<ESceneType, string> SceneNameDict = new Dictionary<ESceneType, string>()
    {
        {ESceneType.Game, "GameScene"},
    };

    private static Dictionary<ESkillType, string> SkillNameDict = new Dictionary<ESkillType, string>()
    {
        {ESkillType.BurstArrow, "BurstArrow"},
        {ESkillType.Dynamite, "Dynamite"},
        {ESkillType.Shield, "Shield"},
        {ESkillType.AirBrake, "AirBrake"},
    };

    private static Dictionary<EEffectType, string> EffectNameDict = new Dictionary<EEffectType, string>()
    {
        {EEffectType.Explosion, "ExplosionEffect"},
        {EEffectType.ShieldHit, "ShieldEffect"},
        {EEffectType.Hit, "HitEffect"},
        {EEffectType.AirBrake, "AirBrakeEffect"},
        {EEffectType.Blood, "BloodEffect"},
    };

    public static string GetSceneName(ESceneType type) => SceneNameDict[type];
    public static string GetSkillName(ESkillType type) => SkillNameDict[type];
    public static string GetEffectName(EEffectType type) => EffectNameDict[type];
}
