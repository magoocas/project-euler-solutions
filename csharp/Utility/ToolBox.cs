using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Utility
{
    public static class ToolBox
    {
        public static PrimeSieve PrimeSieve { get; } = new PrimeSieve();

        public static bool IsPandigital(int number)
        {
            var count = 0;
            var maxDigit = 1;
            var digits = new bool[10];
            while (number > 0)
            {
                var digit = number%10;
                if (digits[digit] || digit==0)
                    return false;
                digits[digit] = true;
                if (digit > maxDigit) maxDigit = digit;
                number /= 10;
                count++;
            }
            return count==maxDigit;
        }

        public static bool IsPalindrome(int number, int numberBase)
        {
            var num = number;
            var palindrome = num % numberBase;
            while ((num /= numberBase) > 0)
            {
                palindrome = palindrome * numberBase + num % numberBase;
            }
            return number == palindrome;
        }

        public static ulong Base10RotateRightUInt64(ulong number)
        {
            var digits = NumberToDigits(number).ToArray();
            ulong result = digits[0];
            for (int i = digits.Length - 1; i >= 1; i--)
            {
                result = result*10 + digits[i];
            }
            return result;
        }
       
        public static IEnumerable<ulong> NumberToDigits(ulong number, int width = 0)
        {
            var digitCount = 0;
            while (number > 0)
            {
                yield return number % 10;
                number /= 10;
                digitCount++;
            }
            if (digitCount < width)
                yield return 0;
        }

        public static IEnumerable<int> NumberToDigits(int number, int width = 0)
        {
            return NumberToDigits((ulong) number).Select(n=>(int)n);
        }

        public static ulong DigitsToNumber(ulong[] digits, int start, int count)
        {
            ulong result = 0;
            ulong magnitude = 1;

            if (count > 0)
            {
                for (int i = start; i < start + count; i++)
                {
                    result += digits[i] * magnitude;
                    magnitude *= 10;
                }
            }
            else
            {
                for (int i = start; i > start + count; i--)
                {
                    result += digits[i] * magnitude;
                    magnitude *= 10;
                }
            }

            return result;
        }
        public static IEnumerable<ulong> GetPrimeFactors(ulong number, bool shortCircuitOnPrimes = false)
        {
            if (shortCircuitOnPrimes && PrimeSieve[number])
            {
                yield return number;
                yield break;
            }

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
        
        public static IEnumerable<ulong> GetDivisors(ulong number, bool proper = false)
        {
            var primeList = new List<ulong>();
            var countList = new List<long>();
            var indexList = new List<int>();

            foreach (var f in GetPrimeFactors(number).GroupBy(x=>x))
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
        public static ulong Factorial(ulong number)
        {
            ulong result = 1;
            while (number > 1)
                result *= number--;
            return result;
        }

        public static int Factorial(int number)
        {
            return (int) Factorial((ulong) number);
        }
    }
}

