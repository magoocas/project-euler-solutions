/*
    Problem: 37

    Title: Truncatable primes

    Description:
        The number 3797 has an interesting property. Being prime itself, it is possible
        to continuously remove digits from left to right, and remain prime at each
        stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797,
        379, 37, and 3.
        
        Find the sum of the only eleven primes that are both truncatable from left to
        right and right to left.
        
        NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
        

    Url: https://projecteuler.net/problem=37
*/
using csharp.Utility;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Level02
{
    public class Solution037 : SolutionBase
    {
        public override object Answer()
        {
            var primes = new HashSet<ulong>(ToolBox.PrimeSieve.PrimeRange(0, 10000000));
            ulong sum = 0;
            var count = 0;

            foreach (var prime in primes)
            {
                var digits = ToolBox.NumberToDigits(prime).ToArray();

                bool isTruncatable = true;
                for (int i = 1; i < digits.Length; i++)
                {
                    if (!primes.Contains(ToolBox.DigitsToNumber(digits, 0, i)))
                    {
                        isTruncatable = false;
                        break;
                    }
                    if (!primes.Contains(ToolBox.DigitsToNumber(digits, digits.Length - i, i)))
                    {
                        isTruncatable = false;
                        break;
                    }
                }

                if (isTruncatable && digits.Length > 1)
                {
                    sum += prime;
                    if (++count == 11)
                        break;
                }
            }

			return sum;
        }
    }
}

