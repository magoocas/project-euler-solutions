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
            var products = new List<ulong>();

            for (ulong i = 100; i <= 999; i++)
                for (ulong j = i; j <= 999; j++)
                    products.Add(i*j);

            return products.Distinct()
                .OrderByDescending(n => n)
                .First(n=>ToolBox.IsPalindrome(n,10));
        }
    }
}