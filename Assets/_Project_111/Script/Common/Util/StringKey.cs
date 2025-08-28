using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringKey
{
    public const string Player = "Player";
    public const string Enemy = "Enemy";
    public const string Arrow = "Arrow";

    private static Dictionary<ESceneType, string> SceneNameDict = new Dictionary<ESceneType, string>()
    {
        {ESceneType.Game, "GameScene"},
    };

    public static string GetSceneName(ESceneType type) => SceneNameDict[type];

}
