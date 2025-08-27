namespace SongLib
{
    public interface ISpecialActable
    {
        public bool CanSpecialAction();

        public void ActSpecialAction(int idx);
    }
}