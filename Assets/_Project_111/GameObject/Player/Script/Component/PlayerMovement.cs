using UnityEngine;
using SongLib;
using System;

public class PlayerMovement : CreatureMovement<PlayerController>
{
    #region << =========== FIELD =========== >>
    private bool _onMoveLeft;
    private bool _onMoveRight;

    #endregion

    #region << =========== PROPERTIES =========== >>
    public float MoveSpeed => owner.Data.MoveSpeed;
    public bool IsMoving => _onMoveLeft != _onMoveRight;
    #endregion



    public override void Init()
    {
        Delegate moveLeft = new Action<bool>(MoveLeft);
        Delegate moveRight = new Action<bool>(MoveRight);

        Global.Event.Register((int)EEventType.MoveLeft, moveLeft);
        Global.Event.Register((int)EEventType.MoveRight, moveRight);
    }

    public override void MoveTo(Vector3 position)
    {
        owner.transform.position = position;
    }


    private void Update()
    {
        UpdateMove();
    }

    private void UpdateMove()
    {
        if (_onMoveLeft && _onMoveRight)
            return;

        if (_onMoveLeft)
            MoveTo(owner.transform.position + Vector3.left * MoveSpeed * Time.deltaTime);
        else if (_onMoveRight)
            MoveTo(owner.transform.position + Vector3.right * MoveSpeed * Time.deltaTime);
    }

    private void MoveLeft(bool isMove)
    {
        _onMoveLeft = isMove;
    }

    private void MoveRight(bool isMove)
    {
        _onMoveRight = isMove;
    }
}