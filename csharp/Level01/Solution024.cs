/*
    Problem: 24

    Title: Lexicographic permutations

    Description:
        A permutation is an ordered arrangement of objects. For example, 3124 is one
        possible permutation of the digits 1, 2, 3 and 4. If all of the permutations
        are listed numerically or alphabetically, we call it lexicographic order. The
        lexicographic permutations of 0, 1 and 2 are:
        
            012   021   102   120   201   210
        
        What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5,
        6, 7, 8 and 9?

    Url: https://projecteuler.net/problem=24
*/

using System.Collections.Generic;
using System.Linq;
using csharp.Utility;

namespace csharp.Level01
{
    public class Solution024 : SolutionBase
    {
        public override object Answer()
        {

            var digits = new int[10];
            var availableDigits = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var permutation = 999999; //zero based "1 millionth"

            var possibilities = ToolBox.Factorial(availableDigits.Count - 1);
            for (int j = digits.Length-1; j > 0; j--)
            {
                var digitIndex = permutation/possibilities;
                permutation %= possibilities;
                digits[j] = availableDigits[digitIndex];
                availableDigits.RemoveAt(digitIndex);
                possibilities /= j;
            }

            digits[0] = availableDigits[0];

            return digits.Aggregate("",(a,b)=> b+a);
        }
    }
}