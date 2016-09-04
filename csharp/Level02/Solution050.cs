/*
    Problem: 50

    Title: Consecutive prime sum

    Description:
        The prime 41, can be written as the sum of six consecutive primes:
        
            41 = 2 + 3 + 5 + 7 + 11 + 13
        
        This is the longest sum of consecutive primes that adds to a prime below
        one-hundred.
        
        The longest sum of consecutive primes below one-thousand that adds to a prime,
        contains 21 terms, and is equal to 953.
        
        Which prime, below one-million, can be written as the sum of the most
        consecutive primes?
        

    Url: https://projecteuler.net/problem=50
*/

using System.Linq;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution050 : SolutionBase
    {
        public override object Answer()
        {

            var primes = ToolBox.PrimeSieve.GetPrimes(1000000).ToList();

            //establish a reasonable limit for the search
            ulong sum = 0;
            for (int i = 0; i < 21; i++)
                sum += primes[i];
            int limit = 0;
            for (int i = 21; i < primes.Count; i++)
            {
                sum += primes[i] - primes[i - limit++];
                if (sum > 1000000)
                {
                    limit = i;
                    break;
                }
            }
            sum = primes[0];
            int count = 21;
            ulong prime = 2;
            for (int i = 1; i < limit; i++)
            {
                sum += primes[i];
                var currentSum = sum;
                for (int j = 0; i-j>count; j++)
                {
                    currentSum -= primes[j];

                    if (currentSum > 1000000 || !ToolBox.PrimeSieve[currentSum]) continue;
                    count = i - j;
                    prime = currentSum;
                }
            }
            return prime;
        }
    }
}

