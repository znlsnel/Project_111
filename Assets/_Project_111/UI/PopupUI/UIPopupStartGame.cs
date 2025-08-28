using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;
using UnityEngine.UI;
using DG.Tweening;
using VInspector.Libs;

public class UIPopupStartGame : UIPopup
{
    #region << ============== FIELD ============== >>
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _sliderFillEfectImg;
    [SerializeField] private Image _backgroundImg;

    #endregion

    public override int GetPopupID() => (int)EPopupType.StartGame;

    protected override void OnInitPopup()
    {
        MoveSliderEffectImage();

        _slider.onValueChanged.AddListener(OnSliderValueChanged);

    }

    protected override void OnRefresh()
    {
        _slider.value = 0f;
        OnSliderValueChanged(0f);
    }

    private void MoveSliderEffectImage()
    {
        _sliderFillEfectImg.transform.DOKill();
        _sliderFillEfectImg.transform.localPosition = new Vector3(-800f, 0f, 0f);
        _sliderFillEfectImg.transform.DOLocalMoveX(800f, 0.5f).SetEase(Ease.Linear).SetDelay(0.5f).OnComplete(() =>
        {
            MoveSliderEffectImage();
        });
    }

    private void OnSliderValueChanged(float value)
    {
        _backgroundImg.color = _backgroundImg.color.SetAlpha(1f -value);

        if (value == 1f)
        {
            GameSceneManager.Instance.StartGame();
            Global.Popup.ClosePopup(this);
        }
    }

}
