using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData")]
public class SkillDataSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private ESkillType _skillType;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _coolTime;



    public string Name => _name;
    public string Description => _description;
    public ESkillType SkillType => _skillType;
    public Sprite Icon => _icon;
    public int CoolTime => _coolTime;
}