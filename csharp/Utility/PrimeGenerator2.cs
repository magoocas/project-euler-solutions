//Adapted from http://primesieve.org/segmented_sieve.html

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace csharp.Utility
{
    public static class PrimeGenerator2
    {
        public const int SegmentSize = 32768;

        private static PrimeSieve _primeSieve;
        private static List<int> _nextCache;
        private static List<int> _smallPrimeCache;
        private static List<bool> _smallPrimeSieve;
        private static ulong _s;
        private static ulong _n;
        private static ulong _maxSieved;

        public static ulong Min(ulong left, ulong right)
        {
            return left < right ? left : right;
        }

        static PrimeGenerator2()
        {
            ClearCache();
        }

        public static PrimeSieve PrimeSieve => _primeSieve;

        public static void ClearCache()
        {
            _primeSieve = new PrimeSieve();
            _nextCache = new List<int>();
            _smallPrimeCache = new List<int>();
            _smallPrimeSieve = new List<bool>();
            _s = 2;
            _n = 3;
            _maxSieved = 0;
        }

        public static void ExpandSieve(ulong limit)
        {
            limit += limit%SegmentSize;

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


            for (ulong low = _maxSieved; low <= limit; low += SegmentSize)
            {
                // vector used for sieving
                var sieve = new bool[SegmentSize];

                // current segment = interval [low, high]
                ulong high = Min(low + SegmentSize - 1, limit);

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
                    for (int k = _smallPrimeCache[i]*2; j < SegmentSize; j += k)
                        sieve[j] = true;
                    _nextCache[i] = j - SegmentSize;
                }
                
                _primeSieve.AddSegment(sieve);
            }
            _maxSieved = limit;
        }
        
    }

}
