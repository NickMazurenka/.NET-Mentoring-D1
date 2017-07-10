using System;

namespace T12_Patterns
{
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> LazyInstance = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance => LazyInstance.Value;

        private LazySingleton()
        {
            Console.WriteLine("LazySingleton");
        }
    }
}
