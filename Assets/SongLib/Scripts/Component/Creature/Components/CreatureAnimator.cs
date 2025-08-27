using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SongLib
{
    public abstract class CreatureAnimator<T> : MonoBehaviour where T : CreatureController
    {
        [Title("Base Animation Handler")]
        [SerializeField]
        protected SpriteRenderer[] spriteRenderers;

        [SerializeField] protected Animator animator;
        [SerializeField] protected Collider2D _collider2D;

        protected Color currentColor = Color.white;
        protected float currentAlpha = 1f;
        protected MaterialPropertyBlock _propertyBlock;
        private static readonly int ColorProperty = Shader.PropertyToID("_Color");

        protected static Dictionary<string, int> _animatorHashDict = new Dictionary<string, int>();

        protected abstract int _moveHash { get; set; }
        protected abstract int _attackHash { get; set; }
        protected abstract int _dieHash { get; set; }
        protected int _defaultSkillHash { get; set; }

        protected T owner;

        public void TriggerAttack()
        {
            animator.SetTrigger(_attackHash);
        }

        public void TriggerSkill(int skillIdx)
        {
            if (_animatorHashDict.TryGetValue($"Skill{skillIdx}", out int hash))
            {
                animator.SetTrigger(hash);
            }
            else
            {
                animator.SetTrigger(_defaultSkillHash);
            }
        }

        #region << =========== PROPERTIES =========== >>

        public Collider2D Collider2D => _collider2D;

        #endregion

        #region << =========== INIT =========== >>

        protected virtual void Awake()
        {
            if (spriteRenderers.Length == 0)
            {
                spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
            }

            animator = this.GetOrAddComponent<Animator>();
            _propertyBlock = new MaterialPropertyBlock();
        }

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public virtual void Init()
        {
            animator.Rebind();
            SetColor(Color.white);
        }

        #endregion

        #region << =========== ANIMATION =========== >>

        //TODO:highcl - SetState 추상화 고민
        //public abstract void SetState(int stateIdx);
        //public void SetState(int stateIdx) => SetState((PlayerAnimationState)stateIdx);

        protected void PlayTrigger(int triggerHash)
        {
            if (animator != null)
            {
                animator.SetTrigger(triggerHash);
            }
        }

        protected void SetBool(int boolHash, bool value)
        {
            if (animator != null)
            {
                animator.SetBool(boolHash, value);
            }
        }

        #endregion

        #region << =========== DAMAGE =========== >>

        Tween _currentDamageTween;

        public IEnumerator DamagedAnimation()
        {
            _currentDamageTween?.Kill();

            transform.parent.localScale = Vector3.one;
            _currentDamageTween = transform.parent.DOScale(Vector3.one * 1.2f, 0.1f)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.OutQuad);

            SetColor(SetDamageColor());
            yield return _currentDamageTween.WaitForCompletion();
            SetColor(Color.white);
        }

        #endregion

        #region <<========= COLOR =========== >>

        private void SetColor(Color color)
        {
            currentColor = color;
            foreach (var sr in spriteRenderers)
            {
                UtilMaterial.SetShaderProperty(ColorProperty, _propertyBlock, sr, color);
            }
        }

        protected virtual Color SetDamageColor()
        {
            return Color.red;
        }

        public void SetAlpha(float alpha)
        {
            currentAlpha = alpha;

            SetColor(new Color(currentColor.r, currentColor.g, currentColor.b, alpha));
        }

        #endregion


        public void StartMove()
        {
            animator.SetBool(_moveHash, true);
        }

        public void StopMove()
        {
            animator.SetBool(_moveHash, false);
        }

        public void DieTrue()
        {
            animator.SetBool(_dieHash, true);
        }

        public void DieFalse()
        {
            animator.SetBool(_dieHash, false);
        }
    }
}