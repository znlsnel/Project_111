using UnityEngine;
using UnityEngine.UI;
using SongLib;
using TMPro;
using DG.Tweening;

public class UITimer : UIBase
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void SetTime(int time)
    {
        _timerText.text = time.ToString();

        _timerText.transform.DOKill();
        _timerText.transform.localScale = Vector3.one * 0.9f;
        _timerText.transform.DOScale(1f, 0.3f).SetEase(Ease.InOutBack);
    }

    protected override void OnInit()
    {
        
    }

    protected override void OnRefresh()
    {
        
    }
}