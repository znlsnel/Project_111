using UnityEngine;

namespace SongLib
{
    public abstract class CreatureAnimationEvent<T> : MonoBehaviour where T : CreatureController
    {
        protected T owner;

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public virtual void Init()
        {
        }

        public abstract void OnStartAttack();
        public abstract void OnHitAttack();
        public abstract void OnEndAttack();

        public abstract void OnStartSkill();
        public abstract void OnExecuteSkill(int id);
        public abstract void OnHitSkill();
        public abstract void OnEndSkill();
    }
}