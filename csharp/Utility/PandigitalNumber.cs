using System.Collections.Generic;

namespace csharp.Utility
{
    public class PandigitalNumber
    {
        private readonly bool[] _requiredDigits = new bool[10];
        private readonly int _requiredDigitCount;

        public PandigitalNumber(IEnumerable<int> digits)
        {
            foreach (var digit in digits)
            {
                _requiredDigits[digit] = true;
                _requiredDigitCount++;
            }
        }

        public bool IsPandigital(int number)
        {
            var count = _requiredDigitCount;
            var digits = new bool[10];
            while (count-- > 0)
            {
                var digit = number%10;
                if (!_requiredDigits[digit] || digits[digit])
                    return false;
                digits[digit] = true;
            }
            return true;
        }
    }
}
