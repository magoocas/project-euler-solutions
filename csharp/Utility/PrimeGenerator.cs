//Adapted from http://primesieve.org/segmented_sieve.html

using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Utility
{
    public static class PrimeGenerator
    {
        private static List<bool> _cachedSieve;
        private static List<int> _nextCache = new List<int>();
        private static List<int> _smallPrimeCache = new List<int>();
        private static List<bool> _smallPrimeSieve = new List<bool>();
        private static List<ulong> _primeCache = new List<ulong>();
        private static ulong _s = 2;
        private static ulong _n = 3;
        private static ulong _maxSieved = 0;

        public static ulong Min(ulong left, ulong right)
        {
            return left < right ? left : right;
        }

        static PrimeGenerator()
        {
            ClearCache();
        }

        public static void ClearCache()
        {
            _cachedSieve = new List<bool>();
            _nextCache = new List<int>();
            _smallPrimeCache = new List<int>();
            _smallPrimeSieve = new List<bool>();
            _primeCache = new List<ulong>();
            _s = 2;
            _n = 3;
            _maxSieved = 0;
        }

        public static void PrimeSieve(ulong limit, int segmentSize = 32768)
        {
            limit += limit%(ulong) segmentSize;

            if (limit <= _maxSieved)
                return;

            int sqrtLimit = (int) Math.Sqrt(limit);

            // generate small primes <= sqrt
            _smallPrimeSieve.AddRange(Enumerable.Repeat(false, sqrtLimit + 1 - _smallPrimeSieve.Count));
            var smallStart = _smallPrimeCache.LastOrDefault();
            smallStart = smallStart == 0 ? 2 : smallStart;
            for (int i = smallStart; i*i <= sqrtLimit; i++)
                if (!_smallPrimeSieve[i])
                    for (int j = i*i; j <= sqrtLimit; j += i)
                        _smallPrimeSieve[j] = true;


            for (ulong low = _maxSieved; low <= limit; low += (ulong) segmentSize)
            {
                // vector used for sieving
                var sieve = new bool[segmentSize];

                // current segment = interval [low, high]
                ulong high = Min(low + (ulong) segmentSize - 1, limit);

                // store small primes needed to cross off multiples
                for (; _s*_s <= high; _s++)
                {
                    if (!_smallPrimeSieve[(int) _s])
                    {
                        _smallPrimeCache.Add((int) _s);
                        _nextCache.Add((int) (_s*_s - low));
                    }
                }
                // sieve the current segment
                for (int i = 1; i < _smallPrimeCache.Count; i++)
                {
                    int j = _nextCache[i];
                    for (int k = _smallPrimeCache[i]*2; j < segmentSize; j += k)
                        sieve[j] = true;
                    _nextCache[i] = j - segmentSize;
                }


                for (; _n <= high; _n += 2)
                    if (!sieve[(int) (_n - low)]) // n is a prime
                        _primeCache.Add(_n);
            }
            _maxSieved = limit;
        }

        public static List<ulong> GetPrimes(ulong limit, int segmentSize = 32768)
        {
            PrimeSieve(limit, segmentSize);
            return _primeCache;
        }
    }

}
