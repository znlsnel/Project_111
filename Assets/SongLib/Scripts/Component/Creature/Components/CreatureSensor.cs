using UnityEngine;

namespace SongLib
{
    public class CreatureSensor<T> : MonoBehaviour where T : CreatureController
    {
        protected T owner;

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public virtual void Init()
        {
        }
    }
}