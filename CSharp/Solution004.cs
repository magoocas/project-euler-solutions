/*
    Problem: 4

    Title: Largest palindrome product

    Description:
        A palindromic number reads the same both ways. The largest palindrome
        made from the product of two 2-digit numbers is 9009 = 91 Ã— 99.
        Find the largest palindrome made from the product of two 3-digit
        numbers.

    Url: https://projecteuler.net/problem=4
*/

using System.Linq;
using System.Runtime.InteropServices;

namespace ProjectEulerSolutions.CSharp
{
    public class Solution004
    {
        public static int Answer()
        {

            int a = 999;
            int b = 999;
            bool subA = true;

            while (a>=100)
            {
                var product = a*b;
                var testString = product.ToString();
                if (testString == string.Concat(testString.Reverse()))
                    return product;

                a = subA ? a - 1 : a;
                b = !subA ? b - 1 : b;
                subA = !subA;
            }
            return 0;
        }
    }
}

