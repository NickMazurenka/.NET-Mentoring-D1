using System.Configuration;
using System.Diagnostics;

namespace MvcMusicStore.Services
{
    public class StandardPerformanceCounter : IPerformanceCounter
    {
        public void IncrementSuccessfullLoginCount()
        {
            using (var counter =
                new PerformanceCounter(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"],
                    ConfigurationManager.AppSettings["SuccessfullLoginCounterName"], false))
                counter.Increment();
        }

        public void IncrementFailedLoginCount()
        {
            using (var counter =
                new PerformanceCounter(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"],
                    ConfigurationManager.AppSettings["FailedLoginCounterName"], false))
                counter.Increment();
        }

        public void IncrementLogoutCount()
        {
            using (var counter =
                new PerformanceCounter(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"],
                    ConfigurationManager.AppSettings["LogoutCounterName"], false))
                counter.Increment();
        }
    }
}