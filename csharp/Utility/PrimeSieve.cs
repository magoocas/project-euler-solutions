using System;
using System.Collections.Generic;
using System.Text;

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

            public bool this[int bitIndex]
            {
                get { return (_value & 1 << bitIndex) != 0; }
            }
            public override string ToString()
            {
                var localValue = _value;
                var sb = new StringBuilder(32);
                for (int i = 0; i < BitCount; i++)
                {
                    if ((localValue & 0x80000000) != 0)
                        sb.Append("1");
                    else
                        sb.Append("0");
                    localValue <<= 1;
                }
                return sb.ToString();
            }
        }

        private const int BitCount = 32;
        private List<PrimeBitVector> _internalList;
        private ulong _count;

        public PrimeSieve()
        {
            _internalList = new List<PrimeBitVector>();
        }

        public void AddSegment(bool[] sieveSegment)
        {
            if(sieveSegment.Length != PrimeGenerator.SegmentSize)
                throw new Exception("Sieve segment size must match generator.");

            var segmentCount = sieveSegment.Length/BitCount;
            for (int i = 0; i < segmentCount; i++)
            {
                int value = 0;
                for (int j = 0; j < BitCount; j++)
                {
                    if (sieveSegment[i*BitCount + j])
                        value = unchecked(value | 1 << j);

                }
                _internalList.Add(new PrimeBitVector(value));
            }
            _count += (ulong) sieveSegment.Length;
        }

        public bool IsPrime(ulong index)
        {
            if (index % 2 == 0)
                return false;
            if (index > _count)
                PrimeGenerator.ExpandSieve(index);
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
        
        public IEnumerable<ulong> GetPrimes(ulong max = 0, ulong min = 0)
        {
            if(max == 0)
                max = _count;

            if (max > _count)
                PrimeGenerator.ExpandSieve(max);
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
    }
}
