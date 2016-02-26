using System.Collections.Generic;

namespace csharp.Utility
{
    public static class Pandigital
    {
        public static IEnumerable<int> Pick(List<int> digits, int count=1, int start= 0)
        {

            for (int i = start; i < digits.Count; i++)
            {
                var digit = digits[i];

                digits.RemoveAt(i);

                if (count == 1)
                    yield return digit;
                else
                    foreach (var number in Pick(digits, count - 1))
                        yield return number*10 + digit;

                digits.Insert(i, digit);
            }
        }


        public static bool IsPandigital(int num, List<int> digits)
        {
            var isPandigital = true;
            var alreadyEncountered = new bool[10];

            while (num > 0)
            {
                var digit = num % 10;

                if (alreadyEncountered[digit])
                    return false;
                alreadyEncountered[digit] = true;

                if (!digits.Contains(digit))
                    return false;

                num /= 10;
            }
            return true;
        }
    }
}