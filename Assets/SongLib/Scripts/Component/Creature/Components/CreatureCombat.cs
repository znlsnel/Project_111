using UnityEngine;

namespace SongLib
{
    public abstract class CreatureCombat<T> : MonoBehaviour where T : CreatureController
    {
        protected T owner;

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public virtual void Init()
        {
        }

        public abstract void Attack();
        public abstract void StopAttack();
    }
}