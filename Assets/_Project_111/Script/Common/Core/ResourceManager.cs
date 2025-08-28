using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Analytics;
using Object = UnityEngine.Object;
using SongLib;

[Serializable]
public class ResourceManager : BaseResourceManager<ResourceManager>
{

    protected override void NewGameResource()
    {
        base.NewGameResource();

        resourcePrefab = new GameResource<GameObject>("Prefab,Prefab/Projectile,Skill");
        resourceUIPopup = new GameResourceUIPopup("Popup");
    }

}
