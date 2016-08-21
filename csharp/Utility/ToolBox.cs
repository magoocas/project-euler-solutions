using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Utility
{
    public static class ToolBox
    {
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
        public static IEnumerable<long> NumberToDigits(long number, int width = 0)
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

        public static int DigitsToNumber(int[] digits, int start, int count)
        {
            int result = 0;
            int magnitude = 1;
            
            if(count > 0)
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

        public static IEnumerable<int> NumberToDigits(int number, int width = 0)
        {
            var digitCount = 0;
            while (number>0)
            {
                yield return number%10;
                number /= 10;
                digitCount++;
            }
            if (digitCount < width)
                yield return 0;
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
        public static long DigitsToNumber(long[] digits, int start, int count)
        {
            long result = 0;
            long magnitude = 1;

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
        public static IEnumerable<ulong> GetPrimeFactors(ulong number)
        {
            if (PrimeGenerator.PrimeSieve[number])
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
        public  static ulong Min(ulong left, ulong right)
        {
            return left < right ? left : right;
        }

        public static IEnumerable<ulong> GetPrimes(ulong limit, int segment_size = 32768)
        {
            {
                int sqrt = (int)Math.Sqrt(limit);
                ulong count = (limit < 2) ? 0ul : 1ul;
                ulong s = 2;
                ulong n = 3;

                yield return 2ul;
                // generate small primes <= sqrt
                var is_prime = new bool[sqrt + 1];

                for (int i = 2; i * i <= sqrt; i++)
                    if (!is_prime[i])
                        for (int j = i * i; j <= sqrt; j += i)
                            is_prime[j] = true;

                var primes = new List<int>();
                var next = new List<int>(); ;

                for (ulong low = 0; low <= limit; low += (ulong)segment_size)
                {
                    // vector used for sieving
                    var sieve = new bool[segment_size];

                    // current segment = interval [low, high]
                    ulong high = Min(low + (ulong)segment_size - 1, limit);

                    // store small primes needed to cross off multiples
                    for (; s * s <= high; s++)
                    {
                        if (!is_prime[(int)s])
                        {
                            primes.Add((int)s);
                            next.Add((int)(s * s - low));
                        }
                    }
                    // sieve the current segment
                    for (int i = 1; i < primes.Count; i++)
                    {
                        int j = next[i];
                        for (int k = primes[i] * 2; j < segment_size; j += k)
                            sieve[j] = true;
                        next[i] = j - segment_size;
                    }

                    for (; n <= high; n += 2)
                        if (!sieve[(int)(n - low)]) // n is a prime
                        {
                            count++;
                            yield return n;
                        }
                }
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

