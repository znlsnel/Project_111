using System;
using UnityEngine;
using UnityEngine.UI;

namespace SongLib
{
    public abstract class CreatureController : BaseObject, IDamageable
    {
        #region << =========== FLAG =========== >>

        public abstract bool IsAttackBan { get; set; }

        #endregion
        
        #region << =========== PROPERTIES =========== >>

        public abstract bool IsDead { get; }

        #endregion

        #region << =========== FIELDS =========== >>

        [SerializeField] protected Image healthBarImg;

        protected GameObject bodyObj;
        protected GameObject healthBar;

        #endregion

        #region << =========== EVENTS =========== >>

        public Action<CreatureStateType> OnStateChanged = null;
        public Action<CreatureController> OnInit = null;
        public Action<CreatureController> OnDead = null;
        public Action<CreatureController> OnDespawn = null;

        #endregion

        #region << =========== PROPERTIES =========== >>

        public BehaviorMode BehaviorModeType { get; set; } = BehaviorMode.Normal;
        public Vector3 OriginPos { get; protected set; }

        public Image HealthBarImg => healthBarImg;
        public IDamageable Target { get; protected set; }
        public Vector3 TargetPos { get; protected set; }

        #endregion

        #region << =========== UNITY EVENTS =========== >>

        protected virtual void Awake()
        {
            healthBar = healthBarImg.transform.parent.gameObject;
        }

        #endregion

        #region << =========== INIT =========== >>

        public override void Init()
        {
        }

        public virtual void Init(int creatureID, int level = 1, Vector3 pos = default)
        {
            if (!IsInitialized)
            {
                InitData(creatureID);
                CreatePrefab(creatureID);
                SetupComponents();
                IsInitialized = true;
            }

            SetLevel(level);
            InitCreature();
            InitComponents();
            SetPosition(pos);
        }

        protected virtual void InitCreature() { }
        protected abstract void InitData(int creatureID);
        protected abstract void CreatePrefab(int creatureID);
        protected abstract void SetupComponents();
        protected virtual void SetLevel(int level) { }
        public override void SetPosition(Vector3 pos)
        {
            base.SetPosition(pos);
            OriginPos = pos;
        }
        protected abstract void InitComponents();

        #endregion

        #region << =========== LIFE CYCLE =========== >>

        public abstract void Dead();
        public abstract void Despawn();

        #endregion

        #region << =========== GET =========== >>

        public override Vector3 GetPosition() => base.GetPosition();

        public abstract float GetDamage();
        public abstract float GetDefense();

        #endregion

        #region << =========== SET =========== >>

        public virtual void SetEvent(Action<CreatureStateType> onStateChanged)
        {
            OnStateChanged += onStateChanged;
        }

        public virtual void SetTarget(IDamageable target)
        {
            Target = target;
        }

        public virtual void SetTargetPosition(Vector3 targetPos)
        {
            TargetPos = targetPos;
        }

        #endregion

        #region << =========== DAMAGE HANDLING =========== >>

        public abstract void TakeDamage(float amount, DamageType type);
        public abstract void KnockBack(float knockbackPower);
        public abstract void TakeDotDamage(float amount, float duration, float interval);

        #endregion
    }
}