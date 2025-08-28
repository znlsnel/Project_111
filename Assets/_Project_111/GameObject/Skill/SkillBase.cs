using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;
using SongLib;

public abstract class SkillBase : MonoBehaviour
{
#region << =============== FIELD =============== >>
    [SerializeField] private SkillDataSO _skillData;
    private CreatureController _owner;
    private float _lastShotTime;
#endregion


#region << =============== PROPERTY =============== >>
    public SkillDataSO SkillData => _skillData;
    public CreatureController Owner => _owner;
    public bool IsUseable => Time.time - _lastShotTime >= _skillData.CoolTime;
#endregion


    #region << =============== EVENT =============== >>
    public event Action OnCoolTimeStart;
    public event Action OnCoolTimeEnd;
#endregion

    public void Setup(CreatureController owner)
    {
        _owner = owner;
        _lastShotTime = -_skillData.CoolTime;
        OnSetup();
    }

    public bool ShotSkill()
    {
        if (Time.time - _lastShotTime < _skillData.CoolTime)
            return false;

        _lastShotTime = Time.time;
        StartCoroutine(CoSetCoolTime());
        OnShot();

        return true;
    }

    protected abstract void OnShot();
    protected abstract void OnSetup();
    
    
    private IEnumerator CoSetCoolTime()
    {
        OnCoolTimeStart?.Invoke();
        yield return new WaitForSeconds(_skillData.CoolTime);
        OnCoolTimeEnd?.Invoke();
    }

}
