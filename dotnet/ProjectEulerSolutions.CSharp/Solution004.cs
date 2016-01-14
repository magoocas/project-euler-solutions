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

using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSolutions.CSharp
{
    public static class Solution004
    {
        public static object Answer()
        {
            var products = new List<int>();

            for (int i=100;i<=999;i++)
                for(int j=100;j<=999;j++)
                    products.Add(i*j);

            return products.OrderByDescending(a => a).First(x =>
            {
                var testString = x.ToString();
                return testString == string.Concat(testString.Reverse());
            });


        }
    }
}

