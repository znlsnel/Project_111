using System;
using UnityEngine;
using UnityEngine.UI;

namespace SongLib
{
    public abstract class CreatureController
    {
        private bool IsInitialized { get; set; }


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
    }
}