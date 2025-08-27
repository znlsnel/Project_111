using System;
using System.Collections.Generic;
using System.Text;
using SongLib;
using UnityEngine;

[Serializable]
public class Stat
{
    private readonly List<StatModifier> _modifiers = new();

    public Stat(float baseValue)
    {
        BaseValue = baseValue;
    }

    [field: SerializeField] public float BaseValue { get; set; }
    public float FinalValue => CalculateFinalValue();

    public void AddModifier(StatModifier modifier_) => _modifiers.Add(modifier_);
    public void RemoveModifier(StatModifier modifier_) => _modifiers.Remove(modifier_);
    public void ClearModifier() => _modifiers.Clear();
    public List<StatModifier> GetModifierList() => _modifiers;

    private float CalculateFinalValue()
    {
        float flatSum = 0f;
        float percentSum = 0f;
        float percentMul = 1f;

        StatModifier constMod = _modifiers.Find(m => m.Type == StatType.Const);
        if (constMod != null) return constMod.Value;

        foreach (var mod in _modifiers)
        {
            switch (mod.Type)
            {
                case StatType.Flat:
                    flatSum += mod.Value;
                    break;
                case StatType.Percent:
                    percentMul *= 1 + (mod.Value / 100f);
                    break;
                case StatType.PercentAdditive:
                    percentSum += mod.Value;
                    break;
            }
        }

        return (BaseValue + flatSum) * (1 + percentSum / 100f) * percentMul;
    }

    public string GetCalculationString()
    {
        StatModifier constMod = _modifiers.Find(m => m.Type == StatType.Const);
        if (constMod != null) return $"{BaseValue} const = {constMod.Value}";

        StringBuilder sb = new StringBuilder();
        sb.Append(BaseValue);

        foreach (var mod in _modifiers)
        {
            if (mod.Type == StatType.Flat)
                sb.Append($" + {mod.Value}");
        }

        float percentSum = 0f;
        foreach (var mod in _modifiers)
        {
            if (mod.Type == StatType.PercentAdditive)
                percentSum += mod.Value;
        }
        if (percentSum != 0f)
            sb.Append($" x (1 + {percentSum / 100f})");

        foreach (var mod in _modifiers)
        {
            if (mod.Type == StatType.Percent)
                sb.Append($" x (1 + {mod.Value / 100f})");
        }

        sb.Append($" = {FinalValue}");

        return sb.ToString();
    }
}
