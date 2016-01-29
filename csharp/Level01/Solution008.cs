/*
    Problem: 8

    Title: Largest product in a series

    Description:
        
        
        The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.

            {Problem008.txt}

        Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?

    Url: https://projecteuler.net/problem=8
*/

using System.Collections.Generic;
using System.Linq;

namespace csharp.Level01
{
    public class Solution008 : SolutionBase
    {
        public override object Answer()
        {
            var windowSize = 13;
            var products = new List<long>();

            for (var i = 0; i < ProblemData.Length - windowSize; i++)
            {
                products.Add(ProblemData.Substring(i, windowSize)
                    .Aggregate(1L, (acc, c) => long.Parse(c.ToString())*acc));
            }
            return products.Max();
        }
    }
}