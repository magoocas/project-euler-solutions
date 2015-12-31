/*
    Problem: 7

    Title: 10001st prime

    Description:
        
        
        By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can
        see that the 6th prime is 13.
        
        What is the 10 001st prime number?

    Url: https://projecteuler.net/problem=7
*/
using System;

namespace ProjectEulerSolutions.CSharp
{
    public class Solution007
    {
        public static int Answer()
        {
            return GetNthPrime(10001, 200000);
        }

        /// <summary>
        /// Gets the nth prime.
        /// </summary>
        /// <returns>The nth prime, if prime less than searchLimit. Otherwise returns -1.</returns>
        /// <param name="n">Nth Prime</param>
        /// <param name="searchLimit">Limit at which to stop searching for prime.</param>
        public static int GetNthPrime(int n, int searchLimit)
        {
            var prime = 2;
            var primeCount = 1;

            var sieve = new bool[searchLimit+1];
            for (int i = 0; i < sieve.Length; i++)
                sieve[i] = true;  
            
            while (primeCount < n)
            {
                for (int multiple = prime * 2; multiple < sieve.Length; multiple += prime)
                    sieve[multiple] = false;

                int possiblePrime;
                for (possiblePrime = prime+1; possiblePrime < sieve.Length; possiblePrime++)
                {
                    if (sieve[possiblePrime])
                    {
                        prime = possiblePrime;
                        primeCount++;
                        break;
                    }
                }
            }

            return primeCount == n ? prime : -1;
        }
    }
}

