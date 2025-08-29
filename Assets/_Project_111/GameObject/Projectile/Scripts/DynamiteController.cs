using UnityEngine;
using SongLib;
using System.Collections;

public class DynamiteController : ProjectileController
{
    private bool _isTargetInRange = false;

    public override void Setup(CreatureController owner)
    {
        base.Setup(owner);
        _isTargetInRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Target.gameObject)
        {
            _isTargetInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == Target.gameObject)
        {
            _isTargetInRange = false;
        }
    }

    protected override void HitGround()
    {
        StartCoroutine(CoExplosion());
    }

    protected override void HitTarget(CreatureController target)
    {

    }


    private IEnumerator CoExplosion()
    {
        yield return new WaitForSeconds(0.5f);

        Managers.Object.CreateEffect(hitEffectType, transform.position, hitEffectSize);

        if (_isTargetInRange)
        {
            Target.TakeDamage(projectileData.Damage, DamageType.Normal);
        }

        Despawn();
    }
}