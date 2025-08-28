using System;
using UnityEngine;

namespace SongLib
{
    public abstract class CreatureStat<T> : MonoBehaviour where T : CreatureController
    {
        protected T owner;

        public virtual void Setup(CreatureController owner)
        {
            this.owner = owner as T;

            SetupStats();
        }

        // Setup -> 최대 1회만 호출
        protected abstract void SetupStats();

        // Init -> 초기화 할때마다 호출
        public void Init()
        {
            InitMetrics();
        }

        protected abstract void InitMetrics();


        #region << =========== HEALTH =========== >>

        public abstract Stat MaxHPStat { get; protected set; }
        public abstract float MaxHP { get; }

        protected float currentHealth = 100f;
        public event Action<float, float> OnHealthChanged;

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, 0f, MaxHP);

                float fillAmount = currentHealth / MaxHP;

                ChangedHealthPoint(fillAmount);
                OnHealthChanged?.Invoke((int)currentHealth, (int)MaxHP);

                if (currentHealth <= 0f)
                {
                    owner.Dead();
                }
            }
        }

        protected abstract void ChangedHealthPoint(float fillAmount);

        #endregion
    }
}