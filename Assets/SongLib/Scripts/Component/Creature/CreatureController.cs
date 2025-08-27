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

        public virtual void Init()
        {
            if (!IsInitialized)
            {
                SetupController();
            }

            InitController();
        }


        protected abstract void SetupController();
        protected abstract void InitController();

        public abstract void Dead();
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