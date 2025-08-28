using SongLib;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileDataSO", menuName = "ScriptableObject/ProjectileDataSO")]
public class ProjectileDataSO : ScriptableObject
{
    [SerializeField, Range(1f, 10f)] public float Speed = 3f;
    [SerializeField, Range(3f, 200f)] public float Damage = 10f;
    [SerializeField, Range(0.1f, 2f)] public float KnockbackPower = 1f;
    [SerializeField, Range(0.1f, 2f)] public float KnockbackTime = 1f;

    [SerializeField, Range(0.1f, 10f)] public float FlightTime = 1f;
    [SerializeField, Range(0f, 10f)] public float ArcHeight = 2f;
}