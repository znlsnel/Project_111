using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UISkillButton : UIBase
{
    [SerializeField] private GameObject _edgeObj;
    [SerializeField] private Image _progressImg;
    [SerializeField] private Image _skillIcon;
    [SerializeField] private Button _skillBtn;
    [SerializeField] private Image _maskImage;
    [SerializeField] private TextMeshProUGUI _coolTimeText;

    private SkillDataSO _skillData;
    private SkillBase _skill;
    private bool _isCooling = false;

    public void SetSkill(SkillBase skill)
    {
        _skill = skill;
        _skillData = _skill.SkillData;
        _skillIcon.sprite = _skillData.Icon;

    }

    protected override void OnInit()
    {
        _skillBtn.onClick.AddListener(OnClickSkill);

        _maskImage.DOFade(0, 0f);
        _coolTimeText.gameObject.SetActive(false);
        SetCanvasGroupAll(true);

        _edgeObj.SetActive(false);
        transform.localScale = Vector3.one;

    }

    protected override void OnRefresh()
    {

    }

    private void OnClickSkill()
    {
        if (_isCooling)
            return;

        if (_skill.ShotSkill())
        {
            StartCoroutine(CoSetProgress(_skillData.CoolTime));

            _maskImage.DOFade(0.5f, 0.5f).SetEase(Ease.OutBack);
            _coolTimeText.gameObject.SetActive(true);
            StartCoroutine(CoSetCoolTime());
            _isCooling = true;

            transform.DOScale(0.8f, 0.3f).SetEase(Ease.OutQuart);

        }
    }

    private IEnumerator CoSetCoolTime()
    {
        int coolTime = _skillData.CoolTime;
        while (coolTime > 0)
        {
            _coolTimeText.text = coolTime.ToString();
            coolTime -= 1;
            yield return new WaitForSeconds(1f);
        }

        _maskImage.DOFade(0, 0.5f).SetEase(Ease.InBack);
        _coolTimeText.gameObject.SetActive(false);
        transform.DOScale(1f, 0.3f).SetEase(Ease.InOutBack);
        _isCooling = false;
    }


    private IEnumerator CoSetProgress(float duration)
    {
        float currentTime = 0f;
        _edgeObj.SetActive(true);

        while (currentTime < duration)
        {
            _progressImg.fillAmount = currentTime / duration;
            currentTime += Time.deltaTime;
            yield return null;
        }

        _edgeObj.SetActive(false);
    }
}
