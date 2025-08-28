using System.Collections;
using System.Collections.Generic;
using SongLib;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPopupGameOver : UIPopup
{

    #region << ============== FIELD ============== >>
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private Button _retryButton;
    #endregion

    public override int GetPopupID() => (int)EPopupType.GameOver;

    protected override void OnInitPopup()
    {
        _retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    protected override void OnRefresh()
    {

    }

    /// <summary>
    /// 1 : 플레이어 승리
    /// 0 : 플레이어 패배
    /// default : 무승부
    /// </summary>
    /// <param name="result"></param>
    public void SetResult(int result)
    {
        _resultText.text = result == 1 ? "YOU WIN ! !" : result == 0 ? "YOU LOSE.." : "IT'S DRAW";
    }

    private void OnRetryButtonClicked()
    {
        Managers.Scene.LoadScene(ESceneType.Game);
        Global.Popup.ClosePopup(this);
    }


}
