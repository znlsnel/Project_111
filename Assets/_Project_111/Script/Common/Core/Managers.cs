
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Managers
{
    // public static 클래스 => 클래스.Instance;
    public static ObjectManager Object => ObjectManager.Instance;
}
