/*
    Problem: 41

    Title: Pandigital prime

    Description:
        We shall say that an n-digit number is pandigital if it makes use of all the
        digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is
        also prime.
        
        What is the largest n-digit pandigital prime that exists?
        

    Url: https://projecteuler.net/problem=41
*/

using csharp.Utility;

namespace csharp.Level02
{
    public class Solution041 : SolutionBase
    {
        
        public override object Answer()
        {
            var primes = PrimeGenerator.GetPrimes(7654321);
            for (int i = primes.Count - 1; i >= 0; i--)
            {
                if (ToolBox.IsPandigital((int)primes[i]))
                    return primes[i];
            }

            return -1;
        }
    }
}

