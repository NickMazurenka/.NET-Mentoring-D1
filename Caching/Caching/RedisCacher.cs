using System.Numerics;
using StackExchange.Redis;

namespace Caching
{
    public class RedisCacher : IFibonacciCacher
    {
        protected readonly IDatabase Database;

        public RedisCacher()
        {
            // Redis
            var redis = ConnectionMultiplexer.Connect("localhost");
            Database = redis.GetDatabase();
        }

        public bool IsCached(int index)
        {
            return Database.KeyExists(index.ToString());
        }

        public void CacheNumber(int index, BigInteger value)
        {
            Database.StringSet(index.ToString(), value.ToString());
        }

        public BigInteger GetCached(int index)
        {
            return BigInteger.Parse(Database.StringGet(index.ToString()));
        }
    }
}
