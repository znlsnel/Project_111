using SongLib;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataSO", menuName = "ScriptableObject/CharacterDataSO")]
public class CharacterDataSO : ScriptableObject
{
    [SerializeField, Range(1f, 5f)] public float MoveSpeed = 3f;
    [SerializeField, Range(0.1f, 2f)] public float AttackDelay = 0.5f;
    [SerializeField, Range(3f, 100f)] public float AttackPower = 10f;
    [SerializeField, Range(1, 10)] public int ArrowAmount = 1;
    [SerializeField, Range(1, 10000)] public int MaxHP = 1000;
}