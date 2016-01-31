using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace csharp
{
    public static class ToolBox
    {
        public static IEnumerable<ulong> GetPrimeFactors(ulong number)
        {
            var numberToFactor = number;
            ulong potentialPrime = 2;
            while (potentialPrime*2 <= numberToFactor)
            {
                var quotient = numberToFactor/potentialPrime;
                var remainder = numberToFactor%potentialPrime;

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
        public static bool[] GetPrimeSieve(ulong searchLimit, Action<ulong> primeEmitter =null)
        {
            ulong prime = 2;

            var sieve = new bool[searchLimit + 1L];
            sieve[0] = sieve[1] = true;

            while (true)
            {
                primeEmitter?.Invoke(prime);

                for (var multiple = prime + prime; multiple < (ulong)sieve.LongLength; multiple += prime)
                    sieve[multiple] = true;

                ulong possiblePrime;
                for (possiblePrime = prime + 1; possiblePrime < (ulong)sieve.LongLength; possiblePrime++)
                {
                    if (!sieve[possiblePrime])
                    {
                        prime = possiblePrime;
                        break;
                    }
                }
                if (possiblePrime == (ulong)sieve.LongLength)
                    break;
            }
            return sieve;
        }

        public static IEnumerable<ulong> GetPrimes(ulong searchLimit)
        {
            ulong prime = 2;

            var sieve = new bool[searchLimit + 1L];
            sieve[0] = sieve[1] = true;

            while (true)
            {
                yield return prime;

                for (var multiple = prime+prime; multiple < (ulong)sieve.LongLength; multiple += prime)
                    sieve[multiple] = true;

                ulong possiblePrime;
                for (possiblePrime = prime + 1; possiblePrime < (ulong) sieve.LongLength; possiblePrime++)
                {
                    if (!sieve[possiblePrime])
                    {
                        prime = possiblePrime;
                        break;
                    }
                }
                if (possiblePrime == (ulong) sieve.LongLength)
                    break;
            }
        }


        public static IEnumerable<ulong> GetDivisors(ulong number, bool proper = false)
        {
            var primeList = new List<ulong>();
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
                ulong divisor = 1;
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

