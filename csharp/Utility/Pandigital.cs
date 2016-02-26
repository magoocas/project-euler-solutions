using System.Collections.Generic;

namespace csharp.Utility
{
    public static class Pandigital
    {
        public static IEnumerable<int> Pick(List<int> digits, int count=-1, int start= 0, int digitMultiplier = 0)
        {
            if (count == -1)
                count = digits.Count;
            
            if (digitMultiplier == 0)
            {
                digitMultiplier = 1;
                for (int i = 1; i < count; i++)
                {
                    digitMultiplier *= 10;
                }
            }

            for (int i = start; i < digits.Count; i++)
            {
                var digit = digits[i];

                digits.RemoveAt(i);

                if (count == 1)
                    yield return digit ;
                else
                    foreach (var number in Pick(digits, count - 1,0,digitMultiplier/10))
                        yield return number + digit * digitMultiplier;

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