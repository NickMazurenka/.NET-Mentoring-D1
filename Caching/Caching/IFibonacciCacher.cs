using System.Numerics;

namespace Caching
{
    public interface IFibonacciCacher
    {
        bool IsCached(int index);

        void CacheNumber(int index, BigInteger value);

        BigInteger GetCached(int index);
    }
}
