using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SongLib;

public class UISkillPanel : UIPanel
{
    [SerializeField] private UISkillButton _skillBtnPrefab;
    [SerializeField] private Transform _skillBtnParent;

    protected override void OnInit()
    {
        List<SkillBase> skills = Managers.Object.Player.Skill.Skills;

        foreach (Transform child in _skillBtnParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var skill in skills)
        {
            var skillBtn = Instantiate(_skillBtnPrefab, _skillBtnParent);
            skillBtn.SetSkill(skill);
            skillBtn.Init();
        }

        SetCanvasGroupAll(true);
    }

    protected override void OnRefresh()
    {
        
    }
}
