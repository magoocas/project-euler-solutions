using System;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Utility
{
    public static class Prime
    {
        public static List<long> GetPrimeFactors(long numberToFactor, long potentialPrime = 2)
        {
            var primes = new List<long>();
            while (potentialPrime * 2 <= numberToFactor)
            {
                long remainder;
                var quotient = Math.DivRem(numberToFactor, potentialPrime, out remainder);

                if (remainder == 0)
                {
                    primes.Add(potentialPrime);
                    numberToFactor = quotient;
                }
                else if (potentialPrime == 2)
                    potentialPrime = 3;
                else
                    potentialPrime = potentialPrime + 2;
            }

            if (numberToFactor > 0)
                primes.Add(numberToFactor);

            return primes;
        }
    }
}
