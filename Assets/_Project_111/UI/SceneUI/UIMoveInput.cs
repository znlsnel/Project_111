using UnityEngine;
using SongLib;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIMoveInput : UIBase
{
    [SerializeField] private Button _leftBtn;
    [SerializeField] private Button _rightBtn;

    protected override void OnInit()
    {
        _leftBtn.GetOrAddComponent<UIPointerDownHandler>().onPointerDown += OnLeftButtonDown;
        _leftBtn.GetOrAddComponent<UIPointerUpHandler>().onPointerUp += OnLeftButtonUp;
        _rightBtn.GetOrAddComponent<UIPointerDownHandler>().onPointerDown += OnRightButtonDown;
        _rightBtn.GetOrAddComponent<UIPointerUpHandler>().onPointerUp += OnRightButtonUp;
    }

    protected override void OnRefresh()
    {

    }
    
    private void OnLeftButtonDown(PointerEventData eventData)
    {
        Global.Event.Trigger((int)EEventType.MoveLeft, true);
    }

    private void OnLeftButtonUp(PointerEventData eventData)
    {
        Global.Event.Trigger((int)EEventType.MoveLeft, false);
    }

    private void OnRightButtonDown(PointerEventData eventData)
    {
        Global.Event.Trigger((int)EEventType.MoveRight, true);
    }

    private void OnRightButtonUp(PointerEventData eventData)
    {   
        Global.Event.Trigger((int)EEventType.MoveRight, false);
    }
}