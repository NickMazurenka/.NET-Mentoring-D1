using System;
using System.Numerics;
using System.Runtime.Caching;

namespace Caching
{
    public class NetCacher : IFibonacciCacher
    {
        private ObjectCache cache;

        public NetCacher()
        {
            cache = MemoryCache.Default;
        }

        public bool IsCached(int index)
        {
            return cache.Contains(index.ToString());
        }

        public void CacheNumber(int index, BigInteger value)
        {
            cache.Add(index.ToString(), value.ToString(), DateTimeOffset.MaxValue);
        }

        public BigInteger GetCached(int index)
        {
            return BigInteger.Parse((string) cache.Get(index.ToString()));
        }
    }
}
