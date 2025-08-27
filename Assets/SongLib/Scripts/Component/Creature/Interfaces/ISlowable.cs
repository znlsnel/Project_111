namespace SongLib
{
    public interface ISlowable
    {
        void ApplySlow(float slowRatio);
        bool IsSlowed { get; set; }
    }
}