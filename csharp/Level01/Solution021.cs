/*
    Problem: 21

    Title: 

    Description:
        Let d(n) be defined as the sum of proper divisors of n (numbers less than n
        which divide evenly into n).
        If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and
        each of a and b are called amicable numbers.
        
        For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55
        and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and
        142; so d(284) = 220.
        
        Evaluate the sum of all the amicable numbers under 10000.
        

    Url: https://projecteuler.net/problem=21
*/

using System.Collections.Generic;
using System.Linq;

namespace csharp.Level01
{
    public class Solution021 : SolutionBase
    {
        private ulong d(ulong n)
        {
            var divisors = ToolBox.GetDivisors(n, true);
            return divisors.Aggregate((a, b) => a + b);
        }

        public override object Answer()
        {
            ulong sum = 0;

            for (ulong a = 1; a <= 10000; a++)
            {
                var b = d(a);
                if (b != a && a == d(b))
                    sum += a;
            }

            return sum;
        }
    }
}