using SongLib;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "ScriptableObject/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField, Range(1f, 5f)] public float MoveSpeed;
    [SerializeField, Range(0.1f, 2f)] public float AttackDelay;
    [SerializeField, Range(3f, 100f)] public float AttackPower;
    [SerializeField, Range(1, 10)] public int ArrowAmount;
}