using UnityEngine;

namespace SongLib
{
    public interface IDamageable
    {
        void TakeDamage(float amount, DamageType type);
        void KnockBack(float knockbackPower);
        Vector3 GetPosition();
    }
}