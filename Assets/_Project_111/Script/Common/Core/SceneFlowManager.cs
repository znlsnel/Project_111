using UnityEngine;
using SongLib;

public class SceneFlowManager : BaseSceneFlowManager<SceneFlowManager>
{
    protected override ISceneTransition AddPopup(int popupID)
    {

        return null;
    }


    public void LoadScene(ESceneType type)
    {
        LoadScene(StringKey.GetSceneName(type));
    }
}