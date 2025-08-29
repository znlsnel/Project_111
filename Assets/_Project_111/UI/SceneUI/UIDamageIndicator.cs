using UnityEngine;
using SongLib;
using UnityEngine.UI;
using DG.Tweening;

public class UIDamageIndicator : UIBase
{
    [SerializeField] private Image _damageImg;

    private Color _defaultColor = "#FF0000".ToColor();
    private Color _clearColor = new Color(0f, 0f, 0f, 0f);

    protected override void OnInit()
    {
        _defaultColor.a = 0.5f;
        _damageImg.color = _clearColor;
        Managers.Object.Player.OnTakeDamage += ShowIndicator;

    }

    protected override void OnRefresh()
    {

    }

    public void ShowIndicator()
    {
        _damageImg.DOColor(_defaultColor, 0.3f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            _damageImg.DOColor(_clearColor, 0.3f).SetEase(Ease.InQuad);
        });
    }
}