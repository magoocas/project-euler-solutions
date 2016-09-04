/*
    Problem: 49

    Title: Prime permutations

    Description:
        The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases
        by 3330, is unusual in two ways: (i) each of the three terms are prime, and,
        (ii) each of the 4-digit numbers are permutations of one another.
        
        There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes,
        exhibiting this property, but there is one other 4-digit increasing sequence.
        
        What 12-digit number do you form by concatenating the three terms in this
        sequence?
        

    Url: https://projecteuler.net/problem=49
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution049 : SolutionBase
    {
        private int[] GetDigitCounts(ulong n)
        {
            var digitCounts = new int[10];
            while (n > 0)
            {
                var digit = n%10;
                digitCounts[digit]++;
                n /= 10;
            }
            return digitCounts;
        }
        private bool IsPermutation(ulong a, ulong b)
        {
            var aDigitCount = GetDigitCounts(a);
            var bDigitCount = GetDigitCounts(b);
            for (int i = 0; i < aDigitCount.Length; i++)
            {
                if (aDigitCount[i] != bDigitCount[i])
                    return false;
            }
            return true;
        }
        public override object Answer()
        {
            var primes = ToolBox.PrimeSieve.PrimeRange(1000, 9999).ToList();

            for (int i = 0; i < primes.Count; i++)
            {
                var p1 = primes[i];
                if(p1 == 1487)
                    continue;
                for (int j = i+1; j < primes.Count; j++)
                {
                    var p2 = primes[j];
                    var p3 = p2 + p2 - p1;
                    if (p3>9999 || !IsPermutation(p1, p2) || !IsPermutation(p1, p3))
                        continue;
                    if (ToolBox.PrimeSieve[p3])
                        return (p1*10000 + p2)*10000 + p3;
                }
            }
            return 0;
        }
    }
}

