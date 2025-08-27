using Sirenix.OdinInspector;
using UnityEngine;

namespace SongLib
{
    public class CreatureMovement<T> : MonoBehaviour, ISlowable where T : CreatureController
    {
        #region << =========== FLAG =========== >>

        [field: Title("Flag")]
        [field: SerializeField] public bool IsSlowed { get; set; }

        #endregion

        protected T owner;

        protected float _moveSpeed;
        protected float _curMoveSpeed;

        #region << =========== INIT =========== >>

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public virtual void Init()
        {
        }

        #endregion

        public virtual void ApplySlow(float slowRatio)
        {
            IsSlowed = true;
            slowRatio = Mathf.Clamp(slowRatio, 0f, 100f);
            _curMoveSpeed = _moveSpeed * (1f - (slowRatio / 100f));
        }

        public virtual void MoveTo(Vector3 position)
        {

        }
    }
}