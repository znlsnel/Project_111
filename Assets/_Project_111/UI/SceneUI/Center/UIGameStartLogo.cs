using UnityEngine;
using SongLib;
using TMPro;
using DG.Tweening;


public class UIGameStartLogo : UIBase
{
    [SerializeField] private TextMeshProUGUI _logoTMP;

    protected override void OnInit()
    {
        _logoTMP.fontSize = 0f;

        DOTween.To(() => _logoTMP.fontSize, x => _logoTMP.fontSize = x, 175f, 0.5f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            _logoTMP.DOFade(0f, 0.5f).SetEase(Ease.InQuad).SetDelay(2f);
        });
    }

    protected override void OnRefresh()
    {

    }
    
    
}