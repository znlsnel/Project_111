namespace SongLib
{
    public interface IStateMachine
    {
        void ChangeState(ECreatureStateType newStateType, object param = null);
        ECreatureStateType CurrentStateType { get; }
    }
}