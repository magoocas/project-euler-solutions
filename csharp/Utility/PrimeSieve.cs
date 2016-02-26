using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //first sieving?
            if (_count == PrimeGenerator2.SegmentSize)
                _internalList[0] = new BitVector32(_internalList[0].Data | 1<<2|1<<3|1<<5|1<<7);
        }

        public bool IsPrime(ulong index)
        {
            var listIndex = (int)index / BitCount;
            var bitIndex = (int)index % BitCount;
            return _internalList[listIndex][bitIndex];
        }
        public bool this[ulong index]
        {
            get { return IsPrime(index); }
        }
        public bool this[int index]
        {
            get { return IsPrime((ulong)index); }
        }

        public ulong Count => _count;


        public IEnumerable<ulong> GetPrimes(ulong min = 0, ulong max = 0)
        {
            int j = (int)min % 32;
            ulong n = min;

            for (int i = (int) min/32; i < _internalList.Count; i++)
            {
                for (; j < 31; j++)
                {
                    if (_internalList[i][j])
                        yield return n;
                    if (++n > max)
                        yield break;
                }
                j = 0;
            }
        }
    }
}
