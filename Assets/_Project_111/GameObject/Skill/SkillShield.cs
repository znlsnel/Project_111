using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SkillShield : SkillBase
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private Collider2D _shieldCollider;
    [SerializeField] private float _shieldDuration;


    protected override void OnSetup()
    {
        _shield.SetActive(false);
        _shieldCollider.enabled = false;

        transform.SetParent(Owner.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    protected override void OnShot()
    {
        _shield.SetActive(true);
        _shield.transform.localScale = Vector3.zero;
        _shield.transform.DOScale(1f, 0.3f).SetEase(Ease.InOutBack);


        _shieldCollider.enabled = true;
        StartCoroutine(CoShield());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ProjectileController>(out ProjectileController pc))
        {
            if (pc.Owner == Owner)
                return;

            Managers.Object.CreateEffect(EEffectType.ShieldHit, pc.transform.position, 2f);
            pc.Despawn();
        }
    }


    private IEnumerator CoShield()
    {
        yield return new WaitForSeconds(_shieldDuration);
        _shieldCollider.enabled = false;

        _shield.transform.DOScale(0f, 0.3f).SetEase(Ease.InOutBack).OnComplete(() =>
        {
            _shield.SetActive(false);
        });
    }
}