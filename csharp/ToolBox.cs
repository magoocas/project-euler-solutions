using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace csharp
{
    public static class ToolBox
    {
        public static IEnumerable<long> GetPrimeFactors(long number)
        {
            var numberToFactor = number;
            long potentialPrime = 2;
            while (potentialPrime*2 <= numberToFactor)
            {
                long remainder;
                var quotient = Math.DivRem(numberToFactor, potentialPrime, out remainder);

                if (remainder == 0)
                {
                    yield return potentialPrime;
                    numberToFactor = quotient;
                }
                else if (potentialPrime == 2)
                    potentialPrime = 3;
                else
                    potentialPrime = potentialPrime + 2;
            }

            if (numberToFactor > 0)
                yield return numberToFactor;
        }


        public static IEnumerable<long> GetPrimes(long searchLimit)
        {
            return GetPrimes(searchLimit, p => true);
        }

        /// <summary>
        ///     Enumerates the primes, so long as predicate returns true
        /// </summary>
        /// <returns>The primes.</returns>
        /// <param name="searchLimit">Search limit.</param>
        /// <param name="predicate">function that takes the current prime number n, and returns true or false</param>
        public static IEnumerable<long> GetPrimes(long searchLimit, Func<long, bool> predicate)
        {
            var prime = 2L;
            var primeCount = 1L;

            var sieve = new bool[searchLimit + 1L];

            while (predicate(primeCount))
            {
                yield return prime;

                for (var multiple = prime*2L; multiple < sieve.LongLength; multiple += prime)
                    sieve[multiple] = true;

                long possiblePrime;
                for (possiblePrime = prime + 1; possiblePrime < sieve.LongLength; possiblePrime++)
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
        ///     Gets the nth prime.
        /// </summary>
        /// <returns>The nth prime, if prime less than searchLimit. Otherwise returns -1.</returns>
        /// <param name="n">Nth Prime</param>
        /// <param name="searchLimit">Limit at which to stop searching for prime.</param>
        public static long GetNthPrime(long n, long searchLimit)
        {
            var primes = GetPrimes(searchLimit, p => p <= n).ToList();

            return primes.Count() == n ? primes.Last() : -1;
        }

        public static int Factorial(int number)
        {
            int result = 1;
            while (number > 1)
                result *= number--;
            return result;
        }
    }
}