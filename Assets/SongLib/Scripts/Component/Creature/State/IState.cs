namespace SongLib
{
    public interface IState
    {
        void Init(CreatureController creatureOwner, IStateMachine stateMachine);

        void Enter(object param);
        void Exit();
        void Tick(float deltaTime);
    }
}