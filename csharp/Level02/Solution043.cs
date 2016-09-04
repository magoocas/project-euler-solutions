/*
    Problem: 43

    Title: Sub-string divisibility

    Description:
        The number, 1406357289, is a 0 to 9 pandigital number because it is made up of
        each of the digits 0 to 9 in some order, but it also has a rather interesting
        sub-string divisibility property.
        
        Let d[1] be the 1^st digit, d[2] be the 2^nd digit, and so on. In this way, we
        note the following:
        
            • d[2]d[3]d[4]=406 is divisible by 2
            • d[3]d[4]d[5]=063 is divisible by 3
            • d[4]d[5]d[6]=635 is divisible by 5
            • d[5]d[6]d[7]=357 is divisible by 7
            • d[6]d[7]d[8]=572 is divisible by 11
            • d[7]d[8]d[9]=728 is divisible by 13
            • d[8]d[9]d[10]=289 is divisible by 17
        
        Find the sum of all 0 to 9 pandigital numbers with this property.
        

    Url: https://projecteuler.net/problem=43
*/

using System.Collections.Generic;
using System.Linq;

namespace csharp.Level02
{
    public class PanDigitialSet
    {
        private List<long> _digitList;
        private bool[] _digits;

        public PanDigitialSet()
        {
            _digits = new bool[10];
            _digitList = new List<long>();
        }

        public IEnumerable<long> UnusedDigits => _digits
            .Select((b, i) => new {b, i})
            .Where(x => !x.b)
            .Select(x => (long)x.i);

        private bool AllDigits(long num, bool leadingZero, bool state)
        {
            if (leadingZero && !_digits[0] == state)
                return false;
            var localDigits = new bool[10];
            while (num > 0)
            {
                var digit = num % 10;
                if (!_digits[digit] == state || localDigits[digit])
                    return false;
                localDigits[digit] = true;
                num /= 10;
            }

            return true;
        }
        

        public bool AddDigits(long num, bool leadingZero, bool addToFront, bool reverseDigits)
        {
            if (!AllDigits(num, leadingZero, false))
                return false;
               
            var insertIndex = 0;
            if (!addToFront)
                insertIndex = _digitList.Count;

            while (num>0)
            {
                var digit = num%10;
                _digits[digit] = true;
                _digitList.Insert(insertIndex, digit);
                num /= 10;
                if (!reverseDigits)
                    insertIndex++;
            }

            if (leadingZero)
            {
                _digits[0] = true;
                _digitList.Insert(insertIndex, 0);
                if (!reverseDigits)
                    insertIndex++;
            }


            return true;
        }

        public bool RemoveDigits(long num, bool leadingZero)
        {
            if (!AllDigits(num, leadingZero, true))
                return false;

            if (leadingZero)
            {
                _digits[0] = false;
                _digitList.Remove(0);
            }
            
            while (num>0)
            {
                var digit = num % 10;
                _digits[digit] = false;
                _digitList.Remove(digit);
                num /= 10;
            }
            return true;
        }

        public long GetNumber(int start = 0, int count = -1)
        {
            long num = 0;
            long multiplier = 1;
            if (count == -1)
                count = _digitList.Count;

            var i = 0;
            for (int index = start; i < count; i++)
            {
                var digit = _digitList[index++];
                num += digit*multiplier;
                multiplier *= 10;
            }
            return num;
        }
        
    }
    public class Solution043 : SolutionBase
    {

        private readonly long[] _primes = new long[] { 13, 11, 7, 5, 3, 2 };
        public override object Answer()
        {
            var digitSet = new PanDigitialSet();

            var matches = new List<long>();
            for (int i = 17; i <= 987; i+=17)
            {
                if(!digitSet.AddDigits(i, i<100, false, false))
                    continue;
                matches.AddRange(MatchingNumbers(digitSet, 0));
                digitSet.RemoveDigits(i, i < 100);
            }
            return matches.Distinct().Sum();
        }

        private IEnumerable<long> MatchingNumbers(PanDigitialSet digitSet, int prime)
        {
            if (prime == _primes.Length)
            {
                var digit = digitSet.UnusedDigits.First();
                if(digit==0)
                    yield break;
                digitSet.AddDigits(digit, false, false, false);
                var number = digitSet.GetNumber();
                digitSet.RemoveDigits(digit, false);
                yield return number;
                yield break;
            }

            foreach (var digit in digitSet.UnusedDigits)
            {
                var num = digit*100 + digitSet.GetNumber(prime + 1, 2);
                if (num%_primes[prime] != 0)
                    continue;
                digitSet.AddDigits(digit, digit==0,false, false);
                foreach (var match in MatchingNumbers(digitSet, prime + 1))
                    yield return match;
                digitSet.RemoveDigits(digit, digit == 0);
            }
        }
    }
}

