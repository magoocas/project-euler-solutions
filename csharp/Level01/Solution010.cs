/*
    Problem: 10

    Title: Summation of primes

    Description:
        
        
        The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        
        Find the sum of all the primes below two million.

    Url: https://projecteuler.net/problem=10
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level01
{
    public class Solution010 : SolutionBase
    {
        public override object Answer()
        {
            return ToolBox.PrimeSieve.GetPrimes(2000000).Aggregate((sum, prime) => sum + prime);
        }
    }
}