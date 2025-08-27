namespace SongLib
{
    public interface IStateMachine
    {
        void ChangeState(CreatureStateType newStateType, object param = null);
        CreatureStateType CurrentStateType { get; }
    }
}