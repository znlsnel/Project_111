using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SongLib
{
    public abstract class CreatureStateMachine<T> : MonoBehaviour, IStateMachine where T : CreatureController
    {
        protected Dictionary<CreatureStateType, IState> states;
        public IState CurrentState { get; private set; }
        [field: SerializeField, ReadOnly] public CreatureStateType CurrentStateType { get; private set; }

        public bool IsInitialized { get; private set; }
        protected T owner;

        #region << =========== INIT =========== >>

        public virtual void Setup(CreatureController creatureOwner)
        {
            owner = creatureOwner as T;
        }

        public virtual void Init(CreatureStateType stateType, object param = null)
        {
            CreateStates();
            InitStates();

            if (states.TryGetValue(stateType, out IState startingState))
            {
                CurrentState = startingState;
                CurrentStateType = stateType;
                startingState.Enter(param);

                IsInitialized = true;
            }
            else
            {
                DebugHelper.LogError(EDebugType.System, $"Failed to initialize state: {stateType}");
            }
        }

        protected abstract void CreateStates();

        private void InitStates()
        {
            foreach (var state in states.Values)
            {
                state.Init(owner, this);
            }
        }

        #endregion

        #region << =========== CHANGE STATE =========== >>

        public void ChangeState(CreatureStateType newStateType, object param = null)
        {
            if (CurrentStateType == newStateType) return;
            if (CurrentStateType == CreatureStateType.Dead) return;

            if (states.TryGetValue(newStateType, out IState newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentStateType = newStateType;

                newState.Enter(param);
            }
            else
            {
                DebugHelper.LogError(EDebugType.System, $"State not found: {newStateType}");
            }
        }

        #endregion

        private void Update()
        {
            if (!IsInitialized) return;

            CurrentState?.Tick(Time.deltaTime);
        }
    }
}