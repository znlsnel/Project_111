using UnityEngine;
using SongLib;
using System;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    /// <summary>
    /// ex) 1분 타이머 설정 => targetTime = 60f
    /// </summary>
    public void SetTimer(Action<int> callbackOnChangedTime, int targetTime)
    {
        StartCoroutine(CoUpdateTimer(callbackOnChangedTime, targetTime));
    }

    private IEnumerator CoUpdateTimer(Action<int> onTimeChanged, int targetTime)
    {
        int currentTime = 0;

        while (true)
        {

            onTimeChanged?.Invoke(currentTime);
            currentTime += 1;
            
            if (currentTime > targetTime)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}