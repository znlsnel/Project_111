using System;
using UnityEngine;
using UnityEngine.UI;

namespace SongLib
{
    public abstract class CreatureController : MonoBehaviour
    {
        private CreatureController _target;
        public CreatureController Target => _target;
        public bool IsInitialized { get; set; }
        public bool IsDead { get; protected set; }
        public event Action OnDead;

        public virtual void Init()
        {
            if (!IsInitialized)
            {
                SetupController();
                IsInitialized = true;
            }

            InitController();
        }


        protected abstract void SetupController();
        protected abstract void InitController();

        public virtual void Dead()
        {
            IsDead = true;
            OnDead?.Invoke();
        }

        public abstract void Despawn();

        public abstract void TakeDamage(float amount, DamageType type);
        public abstract void KnockBack(float knockbackPower);

        public virtual void SetTarget(CreatureController target)
        {
            _target = target;

            if (target.transform.position.x > transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }




}