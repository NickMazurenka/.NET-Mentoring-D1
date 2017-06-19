using System;
using System.Numerics;

namespace Caching
{
    class Program
    {
        protected static IFibonacciCacher Cache;

        static void Main()
        {
            // There's a problem with NetCacher. It resets on program exit :( SO:
            // https://stackoverflow.com/questions/1766657/asp-net-data-cache-preserve-contents-after-app-domain-restart
            Cache = new RedisCacher();//new NetCacher();

            // Fibonacci
            var index = 1;
            BigInteger p = 1;
            BigInteger pp = 0;
            BigInteger current;

            while (true)
            {
                var cached = false;
                // Caching
                if (Cache.IsCached(index))
                {
                    current = Cache.GetCached(index);
                    cached = true;
                }
                else
                {
                    current = pp + p;
                    Cache.CacheNumber(index, current);
                }

                var cachedString = cached ? "+" : "-";
                Console.WriteLine($"{cachedString} n {index++} Fn {current}");
                pp = p;
                p = current;
            }
        }
    }
}