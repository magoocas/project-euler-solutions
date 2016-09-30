using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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

        public static bool IsPalindrome(ulong number, ulong numberBase)
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

        public static IEnumerable<int> NumberToDigits(BigInteger number, int width = 0)
        {
            var digitCount = 0;
            while (number > 0)
            {
                yield return (int)(number % 10);
                number /= 10;
                digitCount++;
            }
            while (digitCount++ < width)
                yield return 0;
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
            while (digitCount++ < width)
                yield return 0;
        }

        public static IEnumerable<int> NumberToDigits(int number, int width = 0)
        {
            return NumberToDigits((ulong) number).Select(n=>(int)n);
        }

        public static ulong DigitsToNumber(ulong[] digits, bool reverse = false)
        {
            if(reverse)
                return DigitsToNumber(digits, digits.Length-1, -digits.Length);
            return DigitsToNumber(digits, 0, digits.Length);
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
            
            foreach (var prime in PrimeSieve.AllPrimes())
            {
                while (prime * prime <= number)
                {
                    var quotient = number / prime;
                    var remainder = number % prime;

                    if (remainder != 0)
                        break;
                    yield return prime;
                    number = quotient;
                }

                if(prime* prime > number)
                    break;
            }
            if (number > 0)
                yield return number;
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

        public static BigInteger Factorial(BigInteger number)
        {
            BigInteger result = 1;
            while (number > 1)
                result *= number--;
            return result;
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

        public static ulong DigitFrequency(ulong number)
        {
            var digitCounter = new ulong[10];
            while (number>0)
            {
                digitCounter[number%10]++;
                number /= 10;
            }
            return DigitsToNumber(digitCounter);
        }

        public static ulong Concatenate(ulong a, ulong b)
        {
            ulong order = 1;
            while ((order *= 10) < b) ;
            return a*order + b;
        }


        //reference: http://stackoverflow.com/a/23718676/4912869
        public static IEnumerable<List<T>> Permutate<T>(IEnumerable<T> source)
        {
            var input = source.ToList();

            if (input.Count == 2) // this are permutations of array of size 2
            {
                yield return new List<T>(input);
                yield return new List<T> { input[1], input[0] };
            }
            else
            {
                foreach (T elem in input) // going through array
                {
                    var rlist = new List<T>(input); // creating subarray = array
                    rlist.Remove(elem); // removing element
                    foreach (List<T> retlist in Permutate(rlist))
                    {
                        retlist.Insert(0, elem); // inserting the element at pos 0
                        yield return retlist;
                    }

                }
            }
        }
    }
}

