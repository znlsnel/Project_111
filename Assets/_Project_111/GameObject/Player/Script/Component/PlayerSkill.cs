using UnityEngine;
using SongLib;
using System.Collections.Generic;

public class PlayerSkill : CreatureSkill<PlayerController>
{
    
    [SerializeField] private ESkillType[] _skillTypes;

    private List<SkillBase> _skills = new List<SkillBase>();
    private CreatureController _target;

    public List<SkillBase> Skills => _skills;

    public override void Setup(CreatureController creatureOwner)
    {
        base.Setup(creatureOwner);

        foreach (ESkillType t in _skillTypes)
        {
            SkillBase skill = Managers.Object.CreateSkill(creatureOwner, t);
            _skills.Add(skill);
        }
    }
    

    public override void Init()
    {

    }
    protected override void SetTarget(CreatureController target)
    {
        _target = target;
    }
}