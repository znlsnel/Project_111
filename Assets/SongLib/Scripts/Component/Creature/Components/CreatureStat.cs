using UnityEngine;

namespace SongLib
{
    public abstract class CreatureStat<T> : MonoBehaviour where T : CreatureController
    {
        protected T owner;

        public virtual void Setup(CreatureController owner)
        {
            this.owner = owner as T;
        }

        protected abstract void SetupStats();

        public void Init()
        {
            InitMetrics();
        }

        protected abstract void InitMetrics();

        #region << =========== HEALTH =========== >>

        public abstract Stat MaxHPStat { get; protected set; }
        public abstract float MaxHP { get; }

        protected float currentHealth = 100f;

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, 0f, MaxHP);

                float fillAmount = currentHealth / MaxHP;
                if (owner.HealthBarImg != null)
                {
                    owner.HealthBarImg.fillAmount = fillAmount;
                }

                OnHealthChanged(fillAmount);

                if (currentHealth <= 0f)
                {
                    owner.Dead();
                }
            }
        }

        protected abstract void OnHealthChanged(float fillAmount);

        #endregion
    }
}