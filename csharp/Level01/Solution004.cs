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
using csharp.Utility;

namespace csharp.Level01
{
    public class Solution004 : SolutionBase
    {
        public override object Answer()
        {
            var products = new List<int>();

            for (var i = 100; i <= 999; i++)
                for (var j = i; j <= 999; j++)
                    products.Add(i*j);

            return products.Distinct().OrderByDescending(a => a).First(x =>
            {
                var num = x;
                var y = num % 10;
                while ((num/=10)>0)
                {
                    y = y*10+num%10;
                }
                return x == y;
                var testString = x.ToString();
                return testString == string.Concat(testString.Reverse());
            });
        }
    }
}