using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using SongLib;

public class UIWorldDamage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _damageTmp;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _criticalColor;
    [SerializeField] private float _moveTime = 0.5f;
    [SerializeField] private float _moveHeighgt = 5f;

    public void SetDamage(float damage)
    {
        _damageTmp.text = damage.ToString("F0");

        if (damage > 100)
            _damageTmp.color = _criticalColor;
        else
            _damageTmp.color = _defaultColor;

        _damageTmp.transform.DOKill();
        _damageTmp.transform.localPosition = Vector3.zero;

        DOTween.To(() => _damageTmp.color, (value) => _damageTmp.color = value, new Color(_damageTmp.color.r, _damageTmp.color.g, _damageTmp.color.b, 0f), _moveTime).SetEase(Ease.InCubic);

        _damageTmp.transform.DOLocalMoveY(_moveHeighgt, _moveTime).SetEase(Ease.InSine).OnComplete(() =>
        {
            Global.Object.Despawn(gameObject);
        });
    }
}
