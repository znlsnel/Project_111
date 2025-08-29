using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongLib;

public class ProjectileFire : ProjectileController
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Coroutine _coFireDamage;
    private bool _isGround = false;
    private bool _isTargetInRange = false;

    public override void Setup(CreatureController owner)
    {
        base.Setup(owner);
        _coFireDamage = null;
        _isGround = false;
        _isTargetInRange = false;
        _spriteRenderer.gameObject.SetActive(true);
    }

    public override void Despawn(float delay = 0f)
    {
        if (_coFireDamage != null)
        {
            StopCoroutine(_coFireDamage);
            _coFireDamage = null;
        }

        base.Despawn(delay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Target.gameObject)
        {
            _isTargetInRange = true;
            if (_isGround)
            {
                _coFireDamage = StartCoroutine(CoFireDamage());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isGround && other.gameObject == Target.gameObject)
        {
            _isTargetInRange = false;
            if (_coFireDamage != null)
            {
                StopCoroutine(_coFireDamage);
                _coFireDamage = null;
            }
        }
    }


    protected override void HitGround()
    {
        _isGround = true;
        _spriteRenderer.gameObject.SetActive(false);
        Managers.Object.CreateEffect(EEffectType.Fire, transform.position, 1f, 5f);
        StartCoroutine(CoDespawn(5f));

        if (_isTargetInRange)
        {
            _coFireDamage = StartCoroutine(CoFireDamage());
        }
    }

    protected override void HitTarget(CreatureController target)
    {
        _spriteRenderer.gameObject.SetActive(false);
        _coFireDamage = StartCoroutine(CoFireDamage());
        StartCoroutine(CoDespawn(3f));
    }


    private IEnumerator CoFireDamage()
    {
        int damageCnt = 10;
        float totalTime = 3f;
        float damage = projectileData.Damage / damageCnt;
        float interval = totalTime / damageCnt;


        for (int i = 0; i < damageCnt; i++)
        {
            Target.TakeDamage(damage, DamageType.Normal);
            Managers.Object.CreateEffect(EEffectType.Fire, Target.transform, 0.3f, interval * 0.7f);

            yield return new WaitForSeconds(interval);
        }

        _coFireDamage = null;
    }

    private IEnumerator CoDespawn(float time)
    {
        yield return new WaitForSeconds(time);
        Despawn();
    }
}
