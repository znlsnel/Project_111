using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISceneGame : UIScene
{
    [SerializeField] private UISceneGameTop _top;
    [SerializeField] private UISceneGameBottom _bottom;


    public UISceneGameTop Top => _top;
    public UISceneGameBottom Bottom => _bottom;
    protected override void OnInit()
    {

    }

    protected override void OnRefresh()
    {
        
    }



}
