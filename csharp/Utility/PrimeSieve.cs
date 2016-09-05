//Adapted from http://primesieve.org/segmented_sieve.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace csharp.Utility
{
    public class PrimeSieve
    {
        private struct PrimeBitVector
        {
            private readonly int _value;

            public PrimeBitVector(int value)
            {
                _value = value;
            }
            public bool this[int bitIndex] => (_value & 1 << bitIndex) != 0;
        }

        private const int BitCount = 32;
        private const int SegmentSize = 32768;
        private List<PrimeBitVector> _internalList;
        private static List<int> _nextCache;
        private static List<int> _smallPrimeCache;
        private static List<bool> _smallPrimeSieve;
        private static ulong _s;
        private static ulong _maxSieved;
        private static int _cachedPrimeCount;


        public PrimeSieve()
        {
            Clear();
        }
        public int Count => _cachedPrimeCount;
        public bool this[ulong num] => IsPrime(num);
        public bool this[int num] => IsPrime((ulong)num);

        public void Clear()
        {
            _internalList = new List<PrimeBitVector>();
            _nextCache = new List<int>();
            _smallPrimeCache = new List<int>();
            _smallPrimeSieve = new List<bool>();
            _s = 2;
            _maxSieved = 0;
        }
        public bool IsPrime(ulong num)
        {
            if (num % 2 == 0)
                return num==2;
            if (num > _maxSieved)
                ExpandSieve(num);
            int listIndex = (int)num / BitCount;
            int bitIndex = (int)num % BitCount;
            return !_internalList[listIndex][bitIndex];
        }
        

        public IEnumerable<ulong> AllPrimes(ulong min = 0)
        {
            while (true)
            {
                foreach (var prime in PrimeRange(min, 0))
                    yield return prime;
                ExpandSieve();
            }
        }

        public IEnumerable<ulong> PrimeRange(ulong min, ulong max)
        {
            if(max == 0)
                max = _maxSieved;

            if (max > _maxSieved)
                ExpandSieve(max);

            if(min<=2)
                yield return 2;

            if(min < 3)
                min = 3;

            ulong n=min;
            if ((min & 1) == 0)
                n++;
            int j = (int)n % BitCount;
            for (int i = (int) n/BitCount; i < _internalList.Count; i++)
            {
                for (; j < BitCount; j+=2, n+=2)
                {
                    if (!_internalList[i][j])
                        yield return n;
                    if (n > max)
                        yield break;
                }
                j = 1;
            }
        }

        private void AddSegment(bool[] sieveSegment)
        {
            int segmentCount = sieveSegment.Length / BitCount;
            for (int i = 0; i < segmentCount; i++)
            {
                int value = 0;
                for (int j = 0; j < BitCount; j++)
                {
                    if (sieveSegment[i*BitCount + j])
                        value = unchecked(value | 1 << j);
                    else
                        _cachedPrimeCount++;

                }
                _internalList.Add(new PrimeBitVector(value));
            }
            _maxSieved += (ulong)sieveSegment.Length;
        }

        private void ExpandSieve(ulong limit = 0)
        {
            if (limit == 0)
                limit = _maxSieved + SegmentSize;


            if (limit <= _maxSieved)
                return;

            if (limit % SegmentSize != 0)
                limit += SegmentSize - (limit % SegmentSize);


            int sqrtLimit = (int)Math.Ceiling(Math.Sqrt(limit));

            // generate small primes <= sqrt
            int smallStart = _smallPrimeSieve.Count - 1;
            _smallPrimeSieve.AddRange(Enumerable.Repeat(false, sqrtLimit - smallStart));
            for (int i = 2; i * i <= sqrtLimit; i++)
            {
                if (_smallPrimeSieve[i]) continue;
                int start = smallStart > 0 ? smallStart - smallStart % i + i : i * i;
                for (int j = start; j <= sqrtLimit; j += i)
                    _smallPrimeSieve[j] = true;
            }



            for (ulong low = _maxSieved; low < limit; low += SegmentSize)
            {
                // vector used for sieving
                bool[] sieve = new bool[SegmentSize];

                // current segment = interval [low, high]
                ulong high = Logic.Min(low + SegmentSize - 1, limit);

                // store small primes needed to cross off multiples
                for (; _s * _s <= high; _s++)
                {
                    if (!_smallPrimeSieve[(int)_s])
                    {
                        _smallPrimeCache.Add((int)_s);
                        _nextCache.Add((int)(_s * _s - low));
                    }
                }
                // sieve the current segment
                for (int i = 1; i < _smallPrimeCache.Count; i++)
                {
                    int j = _nextCache[i];
                    for (int k = _smallPrimeCache[i] * 2; j < SegmentSize; j += k)
                        sieve[j] = true;
                    _nextCache[i] = j - SegmentSize;
                }

                AddSegment(sieve);
            }
            _maxSieved = limit;
        }


    }
}
