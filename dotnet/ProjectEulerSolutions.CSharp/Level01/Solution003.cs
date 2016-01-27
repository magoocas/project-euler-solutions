/*
    Problem: 3

    Title: Largest prime factor

    Description:
        The prime factors of 13195 are 5, 7, 13 and 29.
        What is the largest prime factor of the number 600851475143 ?

    Url: https://projecteuler.net/problem=3
*/

using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSolutions.CSharp.Level01
{
    public class Solution003 : SolutionBase
    {
        public override object Answer()
        {
            var primes = ToolBox.GetPrimeFactors(600851475143);
            return (int) primes.Max();
        }

    }
}