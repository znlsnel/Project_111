using System.Collections;
using System.Collections.Generic;
using SongLib;
using UnityEngine;
using System;

public class ProjectileController : MonoBehaviour
{
#region << =============== FIELD =============== >>
    [SerializeField] private Collider2D _collider;
    [SerializeField] private ProjectileDataSO _projectileData;
    [SerializeField] private bool _canRotate = true;


    private CreatureController _owner;
    private CreatureController _target => _owner.Target;
    private Coroutine _moveCoroutine;
    private float _speed = 1f;
    #endregion

#region << =============== PROPERTY =============== >>
    public CreatureController Owner => _owner;
    public CreatureController Target => _target;
    #endregion

#region << =============== EVENT =============== >>
    public event Action OnDespawn;

#endregion

#region << =============== SETUP =============== >>
    public void Setup(CreatureController owner)
    {
        _owner = owner;
        _collider.enabled = true;
        OnDespawn = null;
        _speed = _projectileData.Speed;
    }

    public void Despawn(float delay = 0f)
    {
        _collider.enabled = false;
        Global.Object.Despawn(gameObject, delay);
        OnDespawn?.Invoke();
    }
    #endregion


    #region << =============== SHOT =============== >>
    public void Shot(Vector3 targetPosition)
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

        _moveCoroutine = StartCoroutine(CoMoveToTarget(targetPosition));
    }
    #endregion
    #region << =============== TRIGGER =============== >>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _target.gameObject)
        {
            HitTarget(_target);
        }
    }
    #endregion
    #region << =============== HIT =============== >>
    private void HitGround()
    {
        Despawn(1f);
    }

    private void HitTarget(CreatureController target)
    {
        if (target == null)
        {
            DebugHelper.LogError(EDebugType.Combat, "HitTarget : target is null");
            return;
        }

        target.TakeDamage(_projectileData.Damage, DamageType.Normal);
        Despawn();
    }
    #endregion
    #region << =============== SLOW =============== >>
    public void OnSlow(float slowPercent, float duration)
    {
        _speed = _projectileData.Speed * (1f - slowPercent);
        StartCoroutine(CoSlow(duration));
    }

    private IEnumerator CoSlow(float duration)
    {
        yield return new WaitForSeconds(duration);
        _speed = _projectileData.Speed;
    }
    #endregion
    #region << =============== MOVE =============== >>
    private IEnumerator CoMoveToTarget(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float distanceToTarget = Vector3.Distance(startPosition, targetPosition);
        if (distanceToTarget <= Mathf.Epsilon)
        {
            transform.position = targetPosition;
            yield break;
        }

        float speed = _projectileData.Speed;
        float totalTime = distanceToTarget / speed;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            float t = elapsedTime / totalTime;

            // 포물선 궤적 계산
            Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, t);

            // 포물선의 높이 계산 (아치 형태)
            float height = _projectileData.ArcHeight * Mathf.Sin(Mathf.PI * t);
            currentPos.y += height;

            // 화살표가 이동 방향을 바라보도록 회전
            float lookaheadT = Mathf.Clamp01(t + (Time.deltaTime / totalTime));
            Vector3 nextPos = Vector3.Lerp(startPosition, targetPosition, lookaheadT);
            nextPos.y += _projectileData.ArcHeight * Mathf.Sin(Mathf.PI * lookaheadT);
            Vector3 direction = (nextPos - currentPos).normalized;

            if (direction != Vector3.zero && _canRotate)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            transform.position = currentPos;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 최종 위치 설정
        transform.position = targetPosition;
        _moveCoroutine = null;

        HitGround();
    }
    #endregion
}
