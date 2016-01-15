/*
    Problem: 16

    Title: Power digit sum

    Description:
        2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
        
        What is the sum of the digits of the number 2^1000?
        

    Url: https://projecteuler.net/problem=16
*/

using System;
using System.Collections.Generic;

namespace ProjectEulerSolutions.CSharp.Solutions
{
    public class Solution016 : SolutionBase
    {
        public override object Answer()
        {
            long number = 2;
            long power = 1000;

            //max number we can safely store in our chosen type
            var maxNum = (long) Math.Pow(10, Math.Floor(Math.Log10(long.MaxValue)) - 1);

            var digits = new List<long>();
            digits.Add(1);

            while (power-- > 0)
            {
                var digitCount = digits.Count;
                long carry = 0;
                for (var i = 0; i < digitCount; i++)
                {
                    carry += number*digits[i];
                    digits[i] = carry%maxNum;
                    carry /= maxNum;
                }
                while (carry != 0)
                {
                    digits.Add(carry%maxNum);
                    carry /= maxNum;
                }
            }

            long sum = 0;
            for (var i = 0; i < digits.Count; i++)
                for (var j = digits[i]; j > 0; j /= 10)
                    sum += j%10;


            return sum;
        }
    }
}