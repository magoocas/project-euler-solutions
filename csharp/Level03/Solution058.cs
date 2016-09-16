/*
    Problem: 58

    Title: Spiral primes

    Description:
        Starting with 1 and spiralling anticlockwise in the following way, a square
        spiral with side length 7 is formed.
        
            37 36 35 34 33 32 31
            38 17 16 15 14 13 30
            39 18  5  4  3 12 29
            40 19  6  1  2 11 28
            41 20  7  8  9 10 27
            42 21 22 23 24 25 26
            43 44 45 46 47 48 49
        
        It is interesting to note that the odd squares lie along the bottom right
        diagonal, but what is more interesting is that 8 out of the 13 numbers lying
        along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.
        
        If one complete new layer is wrapped around the spiral above, a square spiral
        with side length 9 will be formed. If this process is continued, what is the
        side length of the square spiral for which the ratio of primes along both
        diagonals first falls below 10%?
        

    Url: https://projecteuler.net/problem=58
*/

using System;
using System.Collections.Generic;
using System.Threading;
using csharp.Utility;

namespace csharp.Level03
{
    public class Solution058 : SolutionBase
    {
        public override object Answer()
        {
            ulong skip = 2;
            int diag = -1;
            int length = 0;

            int count = 0;
            int primeCount = 0;
            for (ulong i = 1; ; i += skip)
            {
                count++;
                if (ToolBox.PrimeSieve.IsPrime(i))
                    primeCount++;
                var ratio = 100*(double) primeCount/count;

                if (ratio<10 & i>1)
                    break;
                if (diag++ == 3)
                {
                    skip += 2;
                    diag = 0;
                }
            }

            return skip + 1;
        }
    }
}

