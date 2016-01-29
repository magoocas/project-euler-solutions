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


        public static IEnumerable<long> GetDivisors(long number, bool proper = false)
        {
            var primeList = new List<long>();
            var countList = new List<long>();
            var indexList = new List<int>();

            foreach (var f in ToolBox.GetPrimeFactors(number).GroupBy(x=>x))
            {
                primeList.Add(f.Key);
                countList.Add(f.Count());
                indexList.Add(0);
            }
            if(primeList.Count == 0)
            {
                yield return 1;
                if(number > 1 && !proper)
                    yield return number;
                yield break;
            }
            int i = 0;
            while (i < primeList.Count)
            {
                long divisor = 1;
                for (i = 0; i < primeList.Count; i++)
                {
                    for (int j = 0; j < indexList[i]; j++)
                    {
                        divisor *= primeList[i];
                    }
                }


                for (i = 0; i < primeList.Count; i++)
                {
                    indexList[i]++;
                    if (indexList[i] > countList[i])
                        indexList[i] = 0;
                    else
                        break;
                }
                if (proper && i >= primeList.Count)
                    yield break;
                yield return divisor;
            }

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

