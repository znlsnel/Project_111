using UnityEngine;

namespace SongLib
{
    public abstract class CreatureSkill<T> : MonoBehaviour where T : CreatureController
    {
        protected T owner;

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public abstract void Init();

        protected abstract void SetTarget(CreatureController target);
    }
}