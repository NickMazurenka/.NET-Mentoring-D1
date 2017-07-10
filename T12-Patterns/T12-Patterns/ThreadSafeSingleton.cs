using System;

namespace T12_Patterns
{
    public class ThreadSafeSingleton
    {
        private static volatile ThreadSafeSingleton _instance;

        private static readonly object SyncRoot = new object();

        public static ThreadSafeSingleton Instance
        {
            get
            {
                if (_instance == null)
                    lock (SyncRoot)
                        if (_instance == null)
                            _instance = new ThreadSafeSingleton();
                return _instance;
            }
        }

        private ThreadSafeSingleton()
        {
            Console.WriteLine("ThreadSafeSingleton");
        }
    }
}
