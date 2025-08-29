using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using SongLib;
using UnityEngine;
using DG.Tweening;

public class CameraEffect : MonoBehaviour
{
    private CinemachineBasicMultiChannelPerlin _perlin;
    [SerializeField] private float _targetAmplitude = 5f;
    [SerializeField] private float _targetFrequency = 5f;
    [SerializeField] private float _tagetZoom = 3f;
    [SerializeField] private float _damageZoom = 5.3f;
    [SerializeField] private float _completeTime = 0.5f;
    [SerializeField] private float _damageTime = 0.1f;


    private float _defaultZoom;
    private CinemachineVirtualCamera _virtualCamera;

    public float TargetZoom => _defaultZoom - _tagetZoom;
    public float DamageZoom => _defaultZoom - _damageZoom;


    public void Init()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _defaultZoom = _virtualCamera.m_Lens.OrthographicSize;
        _perlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _perlin.m_AmplitudeGain = 0f;
        _perlin.m_FrequencyGain = 0f;
    }

    public void SetShakeGain(float level)
    {
        _perlin.m_AmplitudeGain = _targetAmplitude * level;
        _perlin.m_FrequencyGain = _targetFrequency * level;

        _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(_defaultZoom, TargetZoom, level);
    }

    public void SetDefaultMode()
    {
        DOTween.To(() => _virtualCamera.m_Lens.OrthographicSize, (value) => _virtualCamera.m_Lens.OrthographicSize = value, _defaultZoom, _completeTime).SetEase(Ease.OutQuart);
        DOTween.To(() => _perlin.m_AmplitudeGain, (value) => _perlin.m_AmplitudeGain = value, 0f, _completeTime).SetEase(Ease.OutQuart);
        DOTween.To(() => _perlin.m_FrequencyGain, (value) => _perlin.m_FrequencyGain = value, 0f, _completeTime).SetEase(Ease.OutQuart);
    }

    public void ZoomEffect()
    {
        
        DOTween.To(() => _virtualCamera.m_Lens.OrthographicSize, (value) => _virtualCamera.m_Lens.OrthographicSize = value, DamageZoom, _damageTime).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            DOTween.To(() => _virtualCamera.m_Lens.OrthographicSize, (value) => _virtualCamera.m_Lens.OrthographicSize = value, _defaultZoom, _damageTime).SetEase(Ease.OutQuart);
        });
    }
}
