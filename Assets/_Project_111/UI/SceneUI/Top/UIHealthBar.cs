using UnityEngine;
using SongLib;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class UIHealthBar : UIBase
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _hpText;

    protected override void OnInit()
    {

    }

    protected override void OnRefresh()
    {

    }

    public void Setup<T>(CreatureStat<T> stat) where T : CreatureController
    {
        stat.OnHealthChanged += SetHpInfo;

        _hpSlider.value = 1f;
        _hpText.text = $"{stat.CurrentHealth} / {stat.MaxHP}";
    }

    private void SetHpInfo(float current, float max)
    {
        _hpSlider.DOKill();
        _hpSlider.DOValue(current / max, 0.3f).SetEase(Ease.OutCubic);


        _hpText.text = $"{current} / {max}";
        _hpText.transform.DOKill();
        _hpText.transform.localScale = Vector3.one * 0.8f;
        _hpText.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.InOutBack);

        transform.DOKill();
        transform.localRotation = Quaternion.identity;
        transform.DOLocalRotate(Vector3.forward * 1f, 0.2f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            transform.DOLocalRotate(Vector3.zero, 0.1f, RotateMode.FastBeyond360).SetEase(Ease.InQuad);
        });
    }
}