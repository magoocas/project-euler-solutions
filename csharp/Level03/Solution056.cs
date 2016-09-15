/*
    Problem: 56

    Title: Powerful digit sum

    Description:
        A googol (10^100) is a massive number: one followed by one-hundred zeros; 100^
        100 is almost unimaginably large: one followed by two-hundred zeros. Despite
        their size, the sum of the digits in each number is only 1.
        
        Considering natural numbers of the form, a^b, where a, b < 100, what is the
        maximum digital sum?
        

    Url: https://projecteuler.net/problem=56
*/

using System.Linq;
using System.Numerics;

namespace csharp.Level03
{
    public class Solution056 : SolutionBase
    {
        public override object Answer()
        {
            var max = 0;
            for (var a = 2; a < 100; a++)
            {
                BigInteger n = a;
                for (var b = 2; b < 100; b++)
                {
                    n *= a;
                    var digitSum = n.ToString().Sum(c => c - '0');
                    if (digitSum > max)
                        max = digitSum;
                }
            }
            return max;
        }
    }
}

