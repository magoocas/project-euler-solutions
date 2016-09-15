/*
    Problem: 57

    Title: Square root convergents

    Description:
        It is possible to show that the square root of two can be expressed as an
        infinite continued fraction.
        
            √ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...
        
        By expanding this for the first four iterations, we get:
        
        1 + 1/2 = 3/2 = 1.5
        1 + 1/(2 + 1/2) = 7/5 = 1.4
        1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
        1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...
        
        The next three expansions are 99/70, 239/169, and 577/408, but the eighth
        expansion, 1393/985, is the first example where the number of digits in the
        numerator exceeds the number of digits in the denominator.
        
        In the first one-thousand expansions, how many fractions contain a numerator
        with more digits than denominator?
        

    Url: https://projecteuler.net/problem=57
*/

using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using csharp.Utility;
using Numerics;

namespace csharp.Level03
{
    public class Solution057 : SolutionBase
    {
        private int DigitCount(BigInteger n) => ToolBox.NumberToDigits(n).Count();

        public override object Answer()
        {
            int count = 0;
            var f = (BigRational)1 / 2;
            for (int i = 1; i <= 1000; i++)
            {
                var n = 1 + f;
                f = 1/(2 + f);
                if (DigitCount(n.Numerator) > DigitCount(n.Denominator))
                    count++;
            }
			return count;
        }
    }
}

