using System.Collections;
using System.Collections.Generic;
using SongLib;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private ProjectileDataSO _projectileData;


    private CreatureController _target;
    private Coroutine _moveCoroutine;


    public void Setup(CreatureController target)
    {
        _target = target;
        _collider.enabled = true;
    }


    public void Shot(Vector3 targetPosition)
    {
        InitCoroutine();
        _moveCoroutine = StartCoroutine(CoMoveToTarget(targetPosition));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _target.gameObject)
        {
            HitTarget(_target);
        }
    }

    private void HitGround()
    {
        _collider.enabled = false;
        Global.Object.Despawn(gameObject, 1f);
    }

    private void HitTarget(CreatureController target)
    {
        if (target == null)
        {
            DebugHelper.LogError(EDebugType.Combat, "HitTarget : target is null");
            return;
        }

        target.TakeDamage(_projectileData.Damage, DamageType.Normal);
        InitCoroutine();
        _collider.enabled = false;
        Global.Object.Despawn(gameObject);
    }

    private void InitCoroutine()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

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

            if (direction != Vector3.zero)
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
}
