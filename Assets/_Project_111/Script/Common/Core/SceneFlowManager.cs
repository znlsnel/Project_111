using UnityEngine;
using SongLib;
using DG.Tweening;
using Sirenix.OdinInspector;

public class SceneFlowManager : BaseSceneFlowManager<SceneFlowManager>
{
    protected override ISceneTransition AddPopup(int popupID)
    {

        return null;
    }



    [Button]
    public void ReStart()
    {
        LoadScene(ESceneType.Game);
    }

    public void LoadScene(ESceneType type)
    {
        DOTween.KillAll();

        LoadScene(StringKey.GetSceneName(type));
    }
}