using UnityEngine;

namespace SongLib
{
    public class CreaturePoint<T>: MonoBehaviour where T : CreatureController
    {
        [SerializeField] protected Transform spawnPoint;
        
        public Transform SpawnPoint => spawnPoint;

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