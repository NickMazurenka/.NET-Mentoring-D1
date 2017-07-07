using System;

namespace T12_Patterns
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {
            Console.WriteLine("Instance created");
        }

        public static Singleton Instance => _instance ?? (_instance = new Singleton());
    }
}