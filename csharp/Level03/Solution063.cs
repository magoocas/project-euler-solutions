/*
    Problem: 63

    Title: Powerful digit counts

    Description:
       The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.
       How many n-digit positive integers exist which are also an nth power?

*/


//bounds on number of n-digit numbers for base x:  10^(n-1) <= x^n < 10^n
//therefore for any given base x the upper bound is: x^n < 10^n or x < 10
//and the lower bound is: x^n >= 10^(n-1) or x >= 10^((n-1)/n)
//so to get the count we subtract the lower bound from the upper bound
// count = 10 - 10^((n-1)/n)
//once the lowerbound is greater than or equal to the upper bound we can stop.

using System;
using System.Numerics;
using Numerics;

namespace csharp.Level03
{
    public class Solution063 : SolutionBase
    {
        public override object Answer()
        {
            var count = 0;
            var lower = 0;
            var n = 1;
            while (lower < 10)
            {
                lower = (int)Math.Ceiling(Math.Pow(10, (n - 1.0)/n));
                count += 10 - lower;
                n++;
            }
            return count;
        }
    }
}
