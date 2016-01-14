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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSolutions.CSharp
{
    public static class Solution007
    {
        public static object Answer()
        {
            return GetNthPrime(10001, 200000);
        }

        public static IEnumerable<long> GetPrimes(long searchLimit)
        {
            return GetPrimes(searchLimit, p=>true);
        }

        /// <summary>
        /// Enumerates the primes, so long as predicate returns true
        /// </summary>
        /// <returns>The primes.</returns>
        /// <param name="searchLimit">Search limit.</param>
        /// <param name="predicate">function that takes the current prime number n, and returns true or false</param>
        public static IEnumerable<long> GetPrimes(long searchLimit, Func<long, bool> predicate)
        {
            var prime = 2L;
            var primeCount = 1L;

            var sieve = new bool[searchLimit+1L];

            while (predicate(primeCount))
            {
                yield return prime;

                for (long multiple = prime * 2L; multiple < sieve.LongLength; multiple += prime)
                    sieve[multiple] = true;

                long possiblePrime;
                for (possiblePrime = prime+1; possiblePrime < sieve.LongLength; possiblePrime++)
                {
                    if (!sieve[possiblePrime])
                    {
                        prime = possiblePrime;
                        primeCount++;
                        break;
                    }
                }
                if (possiblePrime == sieve.LongLength)
                    break;
            }
            
        }

        /// <summary>
        /// Gets the nth prime.
        /// </summary>
        /// <returns>The nth prime, if prime less than searchLimit. Otherwise returns -1.</returns>
        /// <param name="n">Nth Prime</param>
        /// <param name="searchLimit">Limit at which to stop searching for prime.</param>
        public static long GetNthPrime(long n, long searchLimit)
        {

            var primes = GetPrimes(searchLimit, p => p <= n).ToList();

            return primes.Count()==n ? primes.Last() : -1;

        }
    }
}

