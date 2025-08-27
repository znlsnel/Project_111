using SongLib;

public class StatModifier
{
    public float Value { get; }
    public StatType Type { get; }

    public StatModifier(float value, StatType type)
    {
        Value = value;
        Type = type;
    }
}