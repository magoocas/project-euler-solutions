using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace csharp.Utility
{
    public class PrimeSieve
    {
        private const int BitCount = 32;
        private List<BitVector32> _internalList;
        private ulong _count;

        public PrimeSieve()
        {
            _internalList = new List<BitVector32>();
        }

        public void AddSegment(bool[] sieveSegment)
        {
            if(sieveSegment.Length != PrimeGenerator2.SegmentSize)
                throw new Exception("Sieve segment size must match generator.");

            var segmentCount = sieveSegment.Length/BitCount;
            for (int i = 0; i < segmentCount; i++)
            {
                int value = 0;
                for (int j = 0; j < BitCount; j++)
                {
                    if (sieveSegment[i*BitCount + j])
                        value |= 1 << j;
                }
                _internalList.Add(new BitVector32(value));
            }
            _count += (ulong)segmentCount*BitCount;
        }

        public bool IsPrime(ulong index)
        {
            if (index % 2 == 0)
                return false;
            if (index > _count)
                PrimeGenerator2.ExpandSieve(index);
            var listIndex = (int)index / BitCount;
            var bitIndex = (int)index % BitCount;
            return !_internalList[listIndex][bitIndex];
        }
        public bool this[ulong index]
        {
            get { return IsPrime(index); }
        }
        public bool this[int index]
        {
            get { return IsPrime((ulong)index); }
        }

        public ulong Count { get { return _count; } }


        public IEnumerable<ulong> GetPrimes(ulong min = 0, ulong max = 0)
        {
            if (max > _count)
                PrimeGenerator2.ExpandSieve(max);
            if(min<=2)
                yield return 2;
            if(min < 3)
                min = 3;

            ulong n = min;
            int j = (int)min % BitCount;
            for (int i = (int) min/BitCount; i < _internalList.Count; i++)
            {
                for (; j < BitCount; j+=2)
                {
                    if (!_internalList[i][j])
                        yield return n;
                    if ((n+=2ul) > max)
                        yield break;
                }
                j = 1;
            }
        }
    }
}
