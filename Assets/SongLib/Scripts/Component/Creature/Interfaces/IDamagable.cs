using UnityEngine;

namespace SongLib
{
    public interface IDamageable
    {
        void TakeDamage(float amount, DamageType type);
        void KnockBack(float knockbackPower);
        // TODO:highcl - 추후 DamageContext로 전환 필요
        void TakeDotDamage(float amount, float duration, float interval);

        Vector3 GetPosition();
    }
}