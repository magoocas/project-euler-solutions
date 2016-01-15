/*
    Problem: 6

    Title: Sum square difference

    Description:
        
        
        The sum of the squares of the first ten natural numbers is,
        1^2 + 2^2 + ... + 10^2 = 385
        
        The square of the sum of the first ten natural numbers is,
        (1 + 2 + ... + 10)^2 = 55^2 = 3025
        
        Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

        Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

    Url: https://projecteuler.net/problem=6
*/

using System;
using System.Linq;

namespace ProjectEulerSolutions.CSharp
{
    public static class Solution006
    {
        public static object Answer()
        {
            var sumOfSquares = Enumerable.Range(1, 100)
                .Select(x => (long) x*(long) x)
                .Aggregate((a, b) => a + b);

            var squareOfSums = (long) Math.Pow(Enumerable.Range(1, 100)
                .Aggregate(0L, (a, b) => a + (long) b), 2);

            return Math.Abs(squareOfSums - sumOfSquares);
        }
    }
}