/*
    Problem: 32

    Title: Pandigital products

    Description:
        We shall say that an n-digit number is pandigital if it makes use of all the
        digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1
        through 5 pandigital.
        
        The product 7254 is unusual, as the identity, 39 x 186 = 7254, containing
        multiplicand, multiplier, and product is 1 through 9 pandigital.
        
        Find the sum of all products whose multiplicand/multiplier/product identity can
        be written as a 1 through 9 pandigital.
        
        HINT: Some products can be obtained in more than one way so be sure to only
        include it once in your sum.

    Url: https://projecteuler.net/problem=32
*/

using System.Collections.Generic;
using System.Linq;

namespace csharp.Level02
{
    public class Solution032 : SolutionBase
    {

        public IEnumerable<int> Pick(List<int> digits, int count, int start= 0)
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

        public bool IsPandigital(int num, List<int> digits)
        {
            var isPandigital = true;
            var alreadyEncountered = new bool[10];

            while (num > 0)
            {
                var digit = num%10;

                if (alreadyEncountered[digit])
                    return false;
                alreadyEncountered[digit] = true;

                if (!digits.Contains(digit))
                    return false;

                num /= 10;
            }
            return true;
        }

        public IEnumerable<int> GetPandigitalProducts(List<int> digits, int firstNumSize, int secondNumSize)
        {
            foreach (var num1 in Pick(digits, firstNumSize))
            {
                foreach (var num2 in Pick(digits, secondNumSize))
                {
                    var product = num1 * num2;
                    if (IsPandigital(product, digits))
                        yield return product;
                }

            }
        } 

        public override object Answer()
        {
            var digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var pandigitalProducts = new HashSet<int>();

            GetPandigitalProducts(digits, 1, 4).ToList().ForEach(x => pandigitalProducts.Add(x));
            GetPandigitalProducts(digits, 2, 3).ToList().ForEach(x => pandigitalProducts.Add(x));
            
            return pandigitalProducts.Sum();
        }
    }
}

