using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class EnemyMovement : CreatureMovement<EnemyController>
{
    private Vector3 _targetPosition = Vector3.zero;
    private bool _isMoving = false;


    public bool IsMoving => _isMoving;
    public float MoveSpeed => owner.Data.MoveSpeed;

    public void MoveToPosition(Vector3 position)
    {
        _targetPosition = position;
        _isMoving = true;
    }
    public override void MoveTo(Vector3 position)
    {
        owner.transform.position = position;
    }
    
    private void Update()
    {
        if (_isMoving)
        {
            if (owner.transform.position.x < _targetPosition.x)
                MoveTo(owner.transform.position + Vector3.right * MoveSpeed * Time.deltaTime);
            else
                MoveTo(owner.transform.position + Vector3.left * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(owner.transform.position, _targetPosition) < 0.1f)
            {
                _isMoving = false;
                _targetPosition = Vector3.zero;
            }
        }
    }



}
