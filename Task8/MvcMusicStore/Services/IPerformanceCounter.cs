namespace MvcMusicStore.Services
{
    public interface IPerformanceCounter
    {
        void IncrementSuccessfullLoginCount();
        void IncrementFailedLoginCount();
        void IncrementLogoutCount();
    }
}
