using System;
using System.Threading;

namespace T12_Patterns
{
    class Program
    {
        private static readonly DateTime StartDateTime = DateTime.Now.AddSeconds(1);

        static void Main()
        {
            // The only issue with singleton implementation from task is that it is not thread-safe.
            // Which means when we have multiple threads, multiple instances of a class could be present, which is unaccaptable.
            
            var threadStart1 = new ThreadStart(Test);
            var threadStart2 = new ThreadStart(Test);
            var th1 = new Thread(threadStart1);
            var th2 = new Thread(threadStart2);

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();
        }

        private static void Test()
        {
            while (DateTime.Now < StartDateTime) ;
            var test = ThreadSafeSingleton.Instance;
            var test2 = Singleton.Instance;
        }
    }
}
