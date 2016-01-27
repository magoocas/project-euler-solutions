/*
    Problem: 10

    Title: Summation of primes

    Description:
        
        
        The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        
        Find the sum of all the primes below two million.

    Url: https://projecteuler.net/problem=10
*/

using System.Linq;

namespace ProjectEulerSolutions.CSharp.Level01
{
    public class Solution010 : SolutionBase
    {
        public override object Answer()
        {
            return ToolBox.GetPrimes(2000000).Aggregate(0L, (sum, prime) => sum + prime);
        }
    }
}