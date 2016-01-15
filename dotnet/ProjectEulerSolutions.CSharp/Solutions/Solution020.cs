/*
    Problem: 20

    Title: 

    Description:
        n! means n x (n − 1) x ... x 3 x 2 x 1
        
        For example, 10! = 10 x 9 x ... x 3 x 2 x 1 = 3628800,
        and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
        
        Find the sum of the digits in the number 100!
        

    Url: https://projecteuler.net/problem=20
*/

using System;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution020 : SolutionBase
    {
        public override object Answer()
        {
            long factorial = 1000;

            //max number we can safely store in our chosen type
            var maxNum = (long) Math.Pow(10, Math.Floor(Math.Log10(long.MaxValue)/Math.Log10(factorial)));

            var digits = new List<long>();
            digits.Add(factorial);
            while (factorial-- > 0)
            {
                var digitCount = digits.Count;
                long carry = 0;
                for (var i = 0; i < digitCount; i++)
                {
                    carry += factorial * digits[i];
                    digits[i] = carry % maxNum;
                    carry /= maxNum;
                }
                while (carry != 0)
                {
                    digits.Add(carry % maxNum);
                    carry /= maxNum;
                }
            }

            long sum = 0;
            for (var i = 0; i < digits.Count; i++)
                for (var j = digits[i]; j > 0; j /= 10)
                    sum += j % 10;


            return sum;
        }
    }
}

