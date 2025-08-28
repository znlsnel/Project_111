using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using SongLib;
using System.Linq;

public class ObjectManager : BaseObjectManager<ObjectManager>
{
    protected override void Reset()
    {

    }

    #region << =========== PLAYER =========== >>
    private PlayerController _player;
    public PlayerController Player => _player;

    public void SpawnPlayer(Vector3 spawnPosition)
    {
        GameObject go = base.Spawn(StringKey.Player, false);
        go.transform.position = spawnPosition;
        go.GetComponent<PlayerController>().Init();
        _player = go.GetComponent<PlayerController>();
    }

    #endregion

    #region << =========== ENEMY =========== >>
    public EnemyController _enemy;
    public EnemyController Enemy => _enemy;
    public void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject go = base.Spawn(StringKey.Enemy, false);
        go.transform.position = spawnPosition;
        go.GetComponent<EnemyController>().Init();
        _enemy = go.GetComponent<EnemyController>();
    }

    #endregion

    #region << =========== EFFECT =========== >>
    public GameObject CreateEffect(string effectName, Vector3 pos, float size = 1f)
    {
        var effect = base.Spawn(effectName, false);
        effect.transform.SetParent(null);
        effect.transform.position = pos;
        effect.transform.localScale *= size;
        return effect;
    }

    public GameObject CreateEffect(string effectName, Transform transform, float size = 1f)
    {
        var effect = base.Spawn(effectName, false);
        effect.transform.SetParent(transform);
        effect.transform.localPosition = Vector3.zero;
        effect.transform.localScale *= size;
        return effect;
    }

    #endregion

    #region << =========== SKILL =========== >>
    public SkillBase CreateSkill(CreatureController owner, ESkillType type)
    {
        GameObject go = base.Spawn(StringKey.GetSkillName(type), false);
        go.transform.position = owner.transform.position;
        go.GetComponent<SkillBase>().Setup(owner);
        return go.GetComponent<SkillBase>();
    }


    private Dictionary<GameObject, HashSet<ProjectileController>> _projectiles = new Dictionary<GameObject, HashSet<ProjectileController>>();
    public ProjectileController CreateArrow(CreatureController owner, Vector3 targetPosition)
    {
        return CreateProjectile(owner, targetPosition, StringKey.Arrow);
    }

    public ProjectileController CreateDynamite(CreatureController owner, Vector3 targetPosition)
    {
        return CreateProjectile(owner, targetPosition, StringKey.Dynamite);
    }

    private ProjectileController CreateProjectile(CreatureController owner, Vector3 targetPosition, string key)
    {
        GameObject go = base.Spawn(key, true);
        go.transform.position = owner.transform.position;
        ProjectileController pc = go.GetComponent<ProjectileController>();
        pc.Setup(owner);
        pc.Shot(targetPosition);

        if (!_projectiles.TryGetValue(owner.gameObject, out HashSet<ProjectileController> projectiles))
        {
            projectiles = new HashSet<ProjectileController>();
            _projectiles[owner.gameObject] = projectiles;
        }
        projectiles.Add(pc);

        pc.OnDespawn += () => projectiles.Remove(pc);
        return pc;
    }

    public List<ProjectileController> GetProjectiles(CreatureController owner)
    {
        if (!_projectiles.TryGetValue(owner.gameObject, out HashSet<ProjectileController> projectiles))
        {
            return new List<ProjectileController>();
        }
        return projectiles.ToList();
    }
    #endregion
}
