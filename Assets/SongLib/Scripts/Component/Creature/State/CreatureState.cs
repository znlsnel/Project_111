namespace SongLib
{
    public abstract class CreatureState<T> : IState where T : CreatureController
    {
        protected T owner;
        protected IStateMachine StateMachine;

        public virtual void Init(CreatureController creatureOwner, IStateMachine stateMachine)
        {
            owner = creatureOwner as T;
            StateMachine = stateMachine;
        }

        public abstract void Enter(object param);
        public abstract void Exit();
        public abstract void Tick(float deltaTime);
    }
}