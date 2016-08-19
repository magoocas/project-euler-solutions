/*
    Problem: 43

    Title: Sub-string divisibility

    Description:
        The number, 1406357289, is a 0 to 9 pandigital number because it is made up of
        each of the digits 0 to 9 in some order, but it also has a rather interesting
        sub-string divisibility property.
        
        Let d[1] be the 1^st digit, d[2] be the 2^nd digit, and so on. In this way, we
        note the following:
        
            • d[2]d[3]d[4]=406 is divisible by 2
            • d[3]d[4]d[5]=063 is divisible by 3
            • d[4]d[5]d[6]=635 is divisible by 5
            • d[5]d[6]d[7]=357 is divisible by 7
            • d[6]d[7]d[8]=572 is divisible by 11
            • d[7]d[8]d[9]=728 is divisible by 13
            • d[8]d[9]d[10]=289 is divisible by 17
        
        Find the sum of all 0 to 9 pandigital numbers with this property.
        

    Url: https://projecteuler.net/problem=43
*/

using System.Collections.Generic;
using csharp.Utility;
using System.Linq;

namespace csharp.Level02
{
    public class Solution043 : SolutionBase
    {

        public override object Answer()
        {
            var pandigitals = Pandigital.Pick(new List<long> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            var primes = new [] { 2, 3, 5, 7, 11, 13, 17 };
            return pandigitals.Where(n =>
            {
                var digits = ToolBox.NumberToDigits(n,10).Reverse().ToArray();
                for (int i = primes.Length-1; i >= 0; i--)
                {
                    var number = ToolBox.DigitsToNumber(digits, i + 3, -3);
                    if (number % primes[i] != 0)
                        return false;
                }
                return true;
            }).Sum();
        }
    }
}

