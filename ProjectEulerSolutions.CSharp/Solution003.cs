/*
    Problem: 3

    Title: Largest prime factor

    Description:
        The prime factors of 13195 are 5, 7, 13 and 29.
        What is the largest prime factor of the number 600851475143 ?

    Url: https://projecteuler.net/problem=3
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSolutions.CSharp
{
    public class Solution003
    {
        public static object Answer()
        {
            var primes = GetPrimeFactors(600851475143);
            return (int)primes.Max();
        }

        public static List<long> GetPrimeFactors(long numberToFactor, long potentialPrime = 2)
        {
            var primes = new List<long>();
            while (potentialPrime * 2 <= numberToFactor)
            {
                long remainder;
                long quotient = Math.DivRem(numberToFactor, potentialPrime, out remainder);

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

